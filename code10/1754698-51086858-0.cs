    public partial class MainWindow : Window
        {
            public ChartValues<LiveCharts.Defaults.ObservableValue> observableValues
            {
                get;
                set;
            }
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                var doubleValues = new ChartValues<double> { 1, 2, 3 };
                var intValues = new ChartValues<int> { 1, 2, 3 };
    
                //note that i'm setting the property and i'm not using 'var' keyword
                observableValues = new ChartValues<LiveCharts.Defaults.ObservableValue>
                {
                    new LiveCharts.Defaults.ObservableValue(1), //initializes Value property as 1
                    new LiveCharts.Defaults.ObservableValue(2),
                    new LiveCharts.Defaults.ObservableValue(3)
                };
            }
        }
