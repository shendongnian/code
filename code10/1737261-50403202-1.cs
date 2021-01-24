    namespace WpfApp2
    {
        public class Class1 : INotifyPropertyChanged
        {
            private bool property = false;
            public bool Property
            {
                get { return property; }
                set { if (value != property) { property = value; RaisePropertyChanged(); } }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName);
        }
    }
