    public class EmployeeClassMap : ClassMap<Employee>
    {
        public EmployeeClassMap
        {
            new ConcreteEmployeeMapper().DoMapping(this);
        }
        private class ConcreteEmployeeMapper : EmployeeMapperBase
        {
            public override Type GetAccountManagerType()
            {
                return typeof(DefaultAccountManager);
            }
        }
    }
