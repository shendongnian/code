    //  This is C#7. If you're using an older version, let me know and I'll update to match. 
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    public class ItemViewModel : ViewModelBase
    {
        private bool _IsItemSelected = default(bool);
        public bool IsItemSelected
        {
            get { return _IsItemSelected; }
            set
            {
                if (value != _IsItemSelected)
                {
                    _IsItemSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        private String _value = default(String);
        public String Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }
    }
