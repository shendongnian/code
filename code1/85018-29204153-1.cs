    public class DummyViewModel : ViewModelBase
        {
            private bool isfocused= false;
            public bool IsFocused
            {
                get
                {
                    return isfocused;
                }
                set
                {
                    isfocused= value;
                    OnPropertyChanged("IsFocused");
                }
            }
        }
 
