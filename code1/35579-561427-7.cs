    namespace WpfApplication6
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                ConnectionViewModel vm = new ConnectionViewModel();
                DataContext = vm;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ((ConnectionViewModel)DataContext).PhonebookEntry = "test";
            }
        }
        public class PhoneBookEntry
        {
            public string Name { get; set; }
            public PhoneBookEntry(string name)
            {
                Name = name;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        public class ConnectionViewModel : INotifyPropertyChanged
        {
            public ConnectionViewModel()
            {
                IList<PhoneBookEntry> list = new List<PhoneBookEntry>();
                list.Add(new PhoneBookEntry("test"));
                list.Add(new PhoneBookEntry("test2"));
                _phonebookEntries = new CollectionView(list);
            }
            private readonly CollectionView _phonebookEntries;
            private string _phonebookEntry;
            public CollectionView PhonebookEntries
            {
                get { return _phonebookEntries; }
            }
            public string PhonebookEntry
            {
                get { return _phonebookEntry; }
                set
                {
                    if (_phonebookEntry == value) return;
                    _phonebookEntry = value;
                    OnPropertyChanged("PhonebookEntry");
                }
            }
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
