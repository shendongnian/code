    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private double _progressValue;
        public double ProgressValue {
            get => _progressValue;
            set
            {
                _progressValue = value;
                NotifyPropertyChanged();
            }
        }
    
        public ObservableCollection<string> Values { get; set; } = new ObservableCollection<string>();
    
        private ICommand _onLoadCommand;
        public ICommand OnLoadCommand
        {
            get
            {
                if (_onLoadCommand == null)
                {
                    _onLoadCommand = new RelayCommand( _ => true, p => OnLoad());
                }
                return _onLoadCommand;
            }
        }
    
        private async void OnLoad()
        {
            var progress = new Progress<Tuple<string, double>>();
            progress.ProgressChanged += OnWorkProgress;
            await DoWork(progress);
        }
    
        private void OnWorkProgress(object sender, Tuple<string, double> e)
        {
            Values.Add(e.Item1);
            NotifyPropertyChanged(nameof(Values));
            ProgressValue = e.Item2 * 100;
        }
    
        private async Task DoWork(IProgress<Tuple<string, double>> progress)
        {
            const int elementsCount = 500;
            for (int index = 0; index < elementsCount; index++)
            {
                var result = "Value_" + index;
                await Task.Delay(50);
                progress.Report(Tuple.Create(result, (double)index / elementsCount));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
