    public class Foo : INotifyPropertyChanged
    {
        private string _fooName;
        private bool _isSelected;
        protected void OnNotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string FooName { get => _fooName; set { _fooName = value; OnNotifyPropertyChanged(nameof(FooName)); } }
        public bool IsSelected { get => _isSelected; set { _isSelected = value; OnNotifyPropertyChanged(nameof(IsSelected)); } }
    }
