    public abstract class EmployeeMapperBase
    {
        protected abstract Type GetAccountManagerType();
        public void DoMapping(ClassMap<Employee> classMap)
        {
            classMap.Id(x => x.Id);
            classMap.Maps(..... etc....
            classMap.References(x => x.AccountManager)
                .Class(GetAccountManagerType());
        }
    }
