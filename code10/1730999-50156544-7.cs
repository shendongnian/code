    using System.ComponentModel;
    using System.Windows;
    namespace WpfApp1
    {
        class VM : INotifyPropertyChanged
        {
            #region WPF integration properties
            public event PropertyChangedEventHandler PropertyChanged;
            // Create the OnPropertyChanged method to raise the event
            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            #endregion
            private Visibility _visibility = Visibility.Hidden;
            public Visibility Visibility
            {
                get { return _visibility; }
                set
                {
                    _visibility = value;
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }
    }
