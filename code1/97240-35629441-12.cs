    public class SomeServiceClass
    {   
        public IQueryable<Employee> GetEmployeeAndPersonDetailIQueryable(IEnumerable<int> employeesToCollect)
        {
			DemoIQueryableEntities db = new DemoIQueryableEntities();
            var allDetails = from Employee e in db.Employees
                             join Person p in db.People on e.PersonId equals p.PersonId
                             where employeesToCollect.Contains(e.PersonId)
                             select e;
            return allDetails;
        }
        public IEnumerable<Employee> GetEmployeeAndPersonDetailIEnumerable(IEnumerable<int> employeesToCollect)
        {
			DemoIQueryableEntities db = new DemoIQueryableEntities();
            var allDetails = from Employee e in db.Employees
                             join Person p in db.People on e.PersonId equals p.PersonId
                             where employeesToCollect.Contains(e.PersonId)
                             select e;
            return allDetails;
        }
	}
