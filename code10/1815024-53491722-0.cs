    namespace UnderstandingINotifyPropertyChanged
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            Class1 Class1Object = new Class1();
            private string _FirstName;
            private string _FullName;
            private string _LastName;
            public string FirstName
            {
                get { return _FirstName; }
                set
                {
                    if (_FirstName != value)
                    {
                        _FirstName = value;
                        RaisePropertyChanged("FirstName");
                        RaisePropertyChanged("FullName");
                    }
                }
            }
            public string LastName
            {
                get { return _LastName; }
                set
                {
                    if (_LastName != value)
                    {
                        _LastName = value;
                        RaisePropertyChanged("Lastname");
                        RaisePropertyChanged("FullName");
                    }
                }
            }
            public string FullName
            {
                get { return _FullName = _FirstName + " " + _LastName; }
            }
            protected virtual void RaisePropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));           
            }
            Class1 ObjectOfClass1 = new Class1();
            public MainWindow()
            {
                InitializeComponent();
                FirstName = "Jeff";
                LastName = "Buckley";
                this.DataContext = this;
                PropertyChanged += ObjectOfClass1.MethodToBeTracked;
            }
        }
        public class Class1
        {
            public void MethodToBeTracked(object sender, PropertyChangedEventArgs e)
            {
                MessageBox.Show("propertychanged event fired due to change in property " + e);
            }
        }
    }
