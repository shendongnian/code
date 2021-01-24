    public class DaoPersonVisitor: IPersonVisitor
    {
        public void Visit(Person person)
        {
            var personDao = new PersonDao();
            personDao.Save(person);
        }
    
        public void Visit(Employee employee)
        {
            var employeeDao = new EmployeeDao();
            employeeDao.Save(employee);
        }
    
        public void Visit(Customer customer)
        {
            var customerDao = new CustomerDao();
            customerDao.Save(customer);
        }
    }
