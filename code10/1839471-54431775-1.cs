    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var items = new List<KeyClientReportModel>
            {
                new KeyClientReportModel
                {
                    Name = "First",
                    Value = 1
                },
                new KeyClientReportModel
                {
                    Name = "Second",
                    Value = 1
                }
            };
            PeriodName = new ObservableCollection<KeyClientReportModel>(items);
        }
        // You don't need to notify changes here because ObservableCollection 
        // send a notification when a change happens. 
        public ObservableCollection<KeyClientReportModel> PeriodName { get; set; }
    }
    public class KeyClientReportModel
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
