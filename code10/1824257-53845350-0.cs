    public class EmployeesController : ApiController
    {
        private DBModel db = new DBModel();
        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }
