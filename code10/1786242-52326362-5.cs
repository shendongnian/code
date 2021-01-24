    public class MainWindow:INotifyPropertyChanged,...
    {
        Progress<Status> _progress;
        private Status _status=new Status();
        public Status Status
        {
            get=>_status;
            set 
            {
                __status=value;
                OnPropertyChanged("Status");
            }
   
        }
        public MainWindow()
        {
            InitializeComponent();
            _progress=new Progress<Status>(OnProgress);
            this.DataContext=this;
        }
        private void OnProgress(Status status)
        {
            Status=status;
        }
