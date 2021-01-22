    public class PersonMapper
    {
        protected List<string> attributes =
            new List<string>() {"firstName", "lastName"};
        public string[] GetAttributes()
        {
            //defensive copy
            return attributes.ToArray();
        }
    }
    public class EmployeeMapper : PersonMapper
    {
        public EmployeeMapper()
        {
            attributes.Add("employeeId");
        }
    }
