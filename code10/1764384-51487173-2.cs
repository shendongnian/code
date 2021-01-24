	public abstract class Employee
    {
        private List<IWorkYear> _workYears;
        //Notice the dependency injection here
        public Employee(IWorkYearProvider workYearProvider)
        {
            WorkYearProvider = workYearProvider;
        }
        //Reference to the dependency
        public IWorkYearProvider WorkYearProvider { get; private set; }
        public IEnumerable<IWorkYear> WorkYears { get => _workYears.AsReadOnly(); private set => _workYears = value.ToList(); }
        public object Id { get; internal set; }
        public void StartWorking(DateTime joinedCompany)
        {
            List<PayPeriod> periods = null; // Calculating periods...
            IWorkYear year = WorkYears.FirstOrDefault(y => y.CurrentYear == joinedCompany.Year);
            if (year == null)
            {
                // Use the dependency to create the object
                year = WorkYearProvider.CreateNewWorkYear(joinedCompany.Year, this, periods);
                _workYears.Add(year);
            }
            else
            {
                // Logic when year not null
            }
            year.RecalculateAllTime();
        }
        // More code...
    }
