     public class CounterModel : INotifyPropertyChanged
    {
        private static CounterModel _instance = new CounterModel();
        public static CounterModel Instance { get { return _instance; } }
        private CounterModel()
        {
            CounterValue = 10;
            startCommand = new StartCommand(Start);
        }
        static DispatcherTimer calcTimer = new DispatcherTimer();
        public StartCommand startCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _counterValue;
        public int CounterValue
        {
            get
            {
                return _counterValue;
            }
            set
            {
                _counterValue = value;
                NotifyPropertyChanged();
            }
        }
        public void Start()
        {
            //Start some stuff..
            Calculate();
        }
        public void Calculate()
        {
            calcTimer.Tick += CalcTimer_Tick;
            calcTimer.Interval = TimeSpan.FromSeconds(2);
            calcTimer.Start();
        }
        private void CalcTimer_Tick(object sender, EventArgs e)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter
                ("Process", "% Processor Time", "Explorer", true);
            CounterValue = (int)cpuCounter.NextValue();
        }
    }
