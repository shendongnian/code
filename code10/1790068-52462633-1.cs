    namespace APE.WPF.Controls.DynamicGrid
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            //public List<CsvGChart> DataContext1 { get; }
            public MainWindow()
            {
                InitializeComponent();
                var context = new TabViewDataContext
                {
                    GanttData = ganttTab(),
                    TableData = tableTab()
                }
                this.DataContext = context;
            }
            public List<SampleGridItem> ganttTab()
            {
                var random = new Random();
                var dataItems = new List<SampleGridItem>();
                for (int x = 0; x < 100; x++)
                {
                    for (int y = 1; y < 10; y++)
                    {
                        dataItems.Add(
                            new SampleGridItem()
                            {
                                ProductionDate = new DateTime(random.Next(2014, 2014), random.Next(1, 12), random.Next(1, 27)),
                                ProductName = string.Format("10-" + y),
                                ProductionCount = random.Next(1, 2) * random.Next(0, 30)
                            });
                    }
                }
                return dataItems;
            }
            //Not sure if this should return that type
            public List<CsvGChart> tableTab()
            {
                return FunctionalFun.UI.CsvParseDataService.ReadFile(@"Unit Records Sample.csv");
            }        
        }
    }
