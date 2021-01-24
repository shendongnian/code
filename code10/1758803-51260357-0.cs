    public class DisplayViewModel
    {
        private readonly ObservableCollection<Employee> _dailyEmployees = new ObservableCollection<Employee>();
        private readonly object _lock = new object();
        public ObservableCollection<Employee> DailyEmployees
        {
            get { return _dailyEmployees; }
        }
        public DisplayViewModel()
        {
            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(_dailyEmployees, _lock);
            OnStatusChanged += DisplayViewModel_OnStatusChanged;
        }
        //invoked in other thread
        private void DisplayViewModel_OnStatusChanged(object sender, EventArgs e)
        {
            var d = sender as Employee;
            if (d == null)
                return;
            var em = DailyEmployees.FirstOrDefault(a => a.Name == d.Name);
            if (em == null)
            {
                DailyEmployees.Add(em);
            }
            else
            {
                em.Status = d.Status;
            }
        }
    }
