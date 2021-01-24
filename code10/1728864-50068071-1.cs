        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
    public class ViewModelBase:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MainWindowViewModel:ViewModelBase
    {
        public MainWindowViewModel()
        {
            ButtonInfo = new ButtonInfo(){Label = "Button Info"};
            ProcessCommand = new DelegateCommand(Process);
        }
        private ButtonInfo _buttonInfo;
        public ButtonInfo ButtonInfo
        {
            get { return _buttonInfo; }
            set
            {
                _buttonInfo = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand ProcessCommand { get; set; }
        private async void Process()
        {
            ButtonInfo = new ProgressInfo(){Label = "Progress Info"};
            await ProcessAsync();
        }
        private Task ProcessAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ButtonInfo.Progress = i;
                        if (i==99)
                        {
                            ButtonInfo = new ButtonInfo(){Label = "Button Again"};
                        }
                    });
                    Thread.Sleep(100);
                }
            });
        }
    }
    public class ButtonInfo:ViewModelBase
    {
        private string _label;
        private int _progress;
        private bool _isProcessing;
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                OnPropertyChanged();
            }
        }
        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }
        public bool IsProcessing
        {
            get { return _isProcessing; }
            set
            {
                _isProcessing = value;
                OnPropertyChanged();
            }
        }
    }
    public class ProgressInfo : ButtonInfo { }
