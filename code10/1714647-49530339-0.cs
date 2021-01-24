    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            TestItemCollection = new ObservableCollection<TestItem>
            {
                new TestItem("Hallo1"),
                 new TestItem("Hallo2"),
                  new TestItem("Hallo3")
                };
        }
        private TestItem m_selectedItemProperty;
        public TestItem SelectedItemProperty
        {
            get
            {
                return m_selectedItemProperty;
            }
            set
            {
                m_selectedItemProperty = value;
                RaisePropertyChanged("SelectedItemProperty");
            }
        }
        public ObservableCollection<TestItem> TestItemCollection
        {
            get;
            set;
        }
        public RelayCommand SelectionChanged
        {
            get { return new RelayCommand(OnSelectionChanged); }
        }
        private void OnSelectionChanged()
        {
            foreach (var item in TestItemCollection)
            {
                if (item.IsSelected)
                    Console.WriteLine("Name: " + item.Name);
            }
        }
    }
