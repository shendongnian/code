    public partial class Page : UserControl
        {
            string[] _names = new string[] { "one", "two", "three" };
    
            public Page()
            {
                InitializeComponent();
                BuildGrid();
            }
    
            public void BuildGrid()
            {
                DataGridTest.ItemsSource = _names;
            }
        }
