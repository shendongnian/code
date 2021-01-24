    public sealed partial class UCDownloadCard : UserControl, INotifyPropertyChanged
        {
            public UCDownloadCard()
            {
                this.InitializeComponent();
            }
            private string downloadCompletePercent;
            public string DownloadCompletePercent
            {
                get
                {
                    return downloadCompletePercent;
                }
                set
                {
                    downloadCompletePercent = value;
                    RaisePropertyChanged("DownloadCompletePercent");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void RaisePropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
