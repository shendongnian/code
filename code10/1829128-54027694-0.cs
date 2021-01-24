    class ReportViewModel : ViewModelBase
    {
        private ObservableCollection<string> error;
        public ObservableCollection<string> Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged("Error");
            }
        }
        private ObservableCollection<string> warning;
        public ObservableCollection<string> Warning
        {
            get { return warning; }
            set { warning = value;
                OnPropertyChanged("Warning");
            }
        }
    
        private ObservableCollection<string> information;
        public ObservableCollection<string> Information
        {
            get { return information; }
            set { information = value;
                OnPropertyChanged("Information");
            }
        }
    
        public ReportViewModel()
        {
            error = new ObservableCollection<string>();
            warning = new ObservableCollection<string>();
            information = new ObservableCollection<string>();
            Warning.Add("Warning");
            Warning.Add("Warning2");
            Error.Add("404");
        }
    
        public void LogError(string severity, string err)
        {
            Warning.Add(err);
            Error.Add(err);
            Information.Add(err);
        }
    }
