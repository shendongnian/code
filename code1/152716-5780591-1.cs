    ...
    public partial class MissingNamesWindow : Window
        {
    
            // Make this accessible from just about anywhere
            public ObservableCollection<ChildName> TheMissingChildren { get; set; }
    
            public MissingNamesWindow()
            {
                // Build our collection so we can bind to it later
                FindMissingChildren();
    
                InitializeComponent();
    
                // Set our datacontext for this window to stuff that lives here
                DataContext = this;
            }
    
            private void FindMissingChildren()
            {
                // Initialize our observable collection
                TheMissingChildren = new ObservableCollection<ChildName>();
    
                // Build our list of objects on list A but not B
                List<ChildName> names = new List<ChildName>(MainWindow.ChildNamesFromDB.Except(MainWindow.ChildNamesFromDisk).ToList());
    
                // Build observable collection from out unique list of objects
                foreach (var name in names)
                {
                    TheMissingChildren.Add(name);
                }
            }
        }
    ...
