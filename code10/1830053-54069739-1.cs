    public class BaseViewModel : INotifyPropertyChanged
        {
            // Bindable properties
            private string _scanInfoLabel = "Test";
            public string ScanInfoLabel
            {
                get { return _scanInfoLabel; }
                set
                {
                    _scanInfoLabel = ScanInfoLabel;
    
                    PropertyChanged(this, new PropertyChangedEventArgs("ScanInfoLabel"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
