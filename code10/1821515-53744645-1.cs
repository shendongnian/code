    class SensorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public System.Windows.Input.ICommand StartCommand { get; set; }
        public string SensorName { get; set; }
        public SensorVM()
        {
            StartCommand = new Xamarin.Forms.Command(StartSubmit);
        }
        private void StartSubmit(object paramter)
        {
            var sensor = new SensorModel()
            {
                Id = 1,
                Sensor = SensorName
            };
            AddSensor(sensor);
        }
        public void AddSensor(SensorModel sensor)
        {
            //do something
        }
    }
