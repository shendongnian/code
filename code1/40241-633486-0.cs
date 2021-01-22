    class Constraint 
    {
        public string Message { get; set; }
        public Func<bool> Validate;
        public string Name { get; set; }
    }
    
    class Age : IDataErrorInfo
    {
        private readonly List<Constraint> _constraints = new List<Constraint>();
    
        public string this[string columnName]
        {
            get 
            {
                var constraint = _constrains.Where(c => c.Name == columnName).FirstOrDefault();
                if (constraint != null)
                {
                    if (!constraint.Validate())
                    {
                        return constraint.Message;
                    }
                }
                return string.Empty;
            }
        }
    }
    
    class Person
    {
        private Age _age;
        
        public Person() 
        {
            _age = new Age(
                new Constraint("Value", "Value must be greater than 28", () => Age > 28);
        }
    }
