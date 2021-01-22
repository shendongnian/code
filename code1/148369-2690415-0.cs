        public partial class MainWindow : Window
    {
        private int _numColumns = 10;
        private int _numRowspercol = 1000;
        public List<DataClass> TheData { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            TheData = new List<DataClass>();
            // Create dummy data
            InitializeTheData();
            var i = 0;
            // Now hook it up to the grid
            foreach (var item in TheData)
            {
                TheGrid.Columns.Add(new Microsoft.Windows.Controls.DataGridTextColumn { Header = item.Heading, Binding = new Binding(string.Format(".[{0}].Values", i++))});
            }
            LayoutGrid.DataContext = TheData;
        }
        private void InitializeTheData()
        {
            Random rand = new Random();
            for (var cols = 0; cols < _numColumns; cols++)
            {
                var newItem = new DataClass();
                newItem.Heading = string.Format("Col: {0:00}", cols + 1);
                newItem.Values = new List<string>();
                for (var rows = 0; rows < _numRowspercol; rows++)
                {
                    newItem.Values.Add(rand.NextDouble().ToString("F4"));
                }
                TheData.Add(newItem);
            }
        }
    }
    public class DataClass
    {
        public string Heading { get; set; }
        public List<string> Values { get; set; }
    }
