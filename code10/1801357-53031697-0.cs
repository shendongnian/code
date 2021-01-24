    public class Foo
    {
        public ObservableCollection<string> _bar = new ObservableCollection<string>();
    
        public ObservableCollection<string> Bar
        {
            get
            {
                Debug.WriteLine("Bar collection called");
                return _bar;
            }
    
            set
            {
                Debug.WriteLine("Bar allocated");
                _bar = value;
            }
        }
    
        public Foo()
        {
            _bar.CollectionChanged += _bar_CollectionChanged;
        }
    
        private void _bar_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("Item added");
        }
    }
    
    public MainWindow()
    {
        Debug.WriteLine("Starting..");
    
        var foo = new Foo
        {
            Bar =
            {
                "one",
                "two"
            }
        };
    
        Debug.WriteLine("Ending..");
    }
