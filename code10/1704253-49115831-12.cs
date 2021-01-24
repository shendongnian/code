     public class DataGridColumnsModel:INotifyPropertyChanged
        {
            private ObservableCollection<string> _dataTypesCollection = new ObservableCollection<string>()
            {
                "Date","String","Number"
            };
            public ObservableCollection<string> DataTypesCollection         
            {
                get { return _dataTypesCollection; }
                set
                {
                    if (Equals(value, _dataTypesCollection)) return;
                    _dataTypesCollection = value;
                    OnPropertyChanged();
                }
            }
    
            private ObservableCollection<Tuple<string, string>> _headerPropertiesCollection=new ObservableCollection<Tuple<string, string>>()
            {
                new Tuple<string, string>("Column 1", "Date"),
                new Tuple<string, string>("Column 2", "String")
    
            };   //The Dictionary has a PropertyName (Item1), and a PropertyDataType (Item2)
            public ObservableCollection<Tuple<string,string>> HeaderPropertyCollection
            {
                get { return _headerPropertiesCollection; }
                set
                {
                    if (Equals(value, _headerPropertiesCollection)) return;
                    _headerPropertiesCollection = value;
                    OnPropertyChanged();
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
 
