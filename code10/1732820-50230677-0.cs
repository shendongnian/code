    public partial class ObjectTab : UserControl
    {
        public ObservableCollection<SomeObject> Objects { get; set; } = new ObservableCollection<SomeObject>();
        public ObjectTab()
        {
            DataContext = this;
            InitializeComponent();
            runWorker();
        }
        ...
        private void refreshAll()
        {
            Shared.DB.read("Some SQL", (ex, dataTable) =>
            {
                var newObjects = dataTable.AsEnumerable().Select((row) => {
                    return new SomeObject()
                    {
                        id = row[0].toString(),
                    };
                }).ToArray();
                Dispatcher.BeginInvoke(new Action(() => 
                {
                    Objects.Clear();
                    foreach (var newObject in newObjects)
                        Objects.Add(newObject);
                }));
            };
        }
    }
