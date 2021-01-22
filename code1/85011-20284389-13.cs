        public class LoginModel : ViewModelBase
        {
            ....
            private bool _EmailFocus = false;
            public bool EmailFocus
            {
                get
                {
                    return _EmailFocus;
                }
                set
                {
                    if (value)
                    {
                        _EmailFocus = false;
                        RaisePropertyChanged("EmailFocus");
                    }
                    _EmailFocus = value;
                    RaisePropertyChanged("EmailFocus");
                }
            }
           ...
       }
