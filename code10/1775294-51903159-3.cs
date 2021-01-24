    public class ViewModel : INotifyPropertyChanged
    {
        private string _test;
        
        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                if(string.Equals(value, _test, StringComparison.CurrentCulture))
                {
                    return;
                }
                _test = value;
                OnPropertyChanged();
            }
        }
    }
