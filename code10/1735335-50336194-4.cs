    public static class PersonDaoFactory
    {
        public static IPersonDao Create(Person person)
        {
            if (person is Employee)
            {
                return new EmployeeDao();
            }
    
            if (person is Customer)
            {
                return new CustomerDao();
            }
    
            /* cases for all the other object in hierarchy */
    
            throw new NotSupportedException($"Can't create DAO for '{person.GetType().FullName}'. Type is not supported.");
        }
    }
