    public class ResultCollection<T> : ObservableCollection<T>
    {
        
            Boolean _val;
            public Boolean Val
            {   
                get
                {   
                    return _val;
                }
                set
                {   
                    _val= value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Val"));
                }
            }
    }
