using PersonelApp.DAL.Repositories.Abstract;
using PersonelApp.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelApp.DAL.Repositories.Concrete
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
            
        }

        public IEnumerable<Department> GetDepartmentsWithPersonnels()
        {
            return PersonelContext.Departments.Include("Personnels").ToList();
        }

        public IEnumerable<Department> GetTopDepartments(int count)
        {
            return PersonelContext.Departments.Take(count);
        }

        public PersonnelContext PersonelContext { get { return _context as PersonnelContext; } }
    }
}
