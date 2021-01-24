    public class SampleEmployee : Employee
    {
        public SampleEmployee(IWorkYearProvider provider) : base(provider) { }
    }
    public class SampleWorkYearProvider : IWorkYearProvider
    {
        public IWorkYear CreateNewWorkYear(int year, Employee employee, List<PayPeriod> periods)
        {
            IWorkYear workYear = null;
            workYear = new WorkYear(year, employee, periods);
            return workYear;
        }        
    }
