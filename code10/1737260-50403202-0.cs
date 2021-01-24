    namespace WpfApp2
    {
        public class Class1 : INotifyPropertyChanged
        {
            private bool property = false;
            public bool Property
            {
                get { return property; }
                set { if (value != property) { property = value; RisePropertyChanged(); } }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RisePropertyChanged([CallerMemberName] string propertyName = "")
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName);
        }
    }
