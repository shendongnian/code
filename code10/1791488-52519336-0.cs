    public class FooModel : Model, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private bool _isFoo;
        public bool IsFoo
        {
            get { return _isFoo; }
            set { _isFoo = value; OnPropertyChanged(); }
        }
        public string FooStr { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
