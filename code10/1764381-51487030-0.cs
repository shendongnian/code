    public class WorkYearData
    {
        WorkYearData(int currentYear, Employee employee, List<PayPeriod> periods)
        {
            CurrentYear = currentYear;
            Employee = employee;
            Periods = periods;
        }
        public int CurrentYear { get; }
        public Employee Employee { get; }
        public List<PayPeriod> Periods { get; }
    }
    public class WorkYearFactory : IFactory<WorkYear, WorkYearData>
    {
        public WorkYear Create(WorkYearData data) 
            => new WorkYear(data.CurrentYear, data.Employee, data.Periods);
    }
