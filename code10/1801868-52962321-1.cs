    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<KeyGroup> keygroups = new List<KeyGroup>();
            ColumnHeaderRow headerrow = new ColumnHeaderRow(keygroups);
            for (int i = 0; i <= 10; i++)
            {
                keygroups.Add(new KeyGroup("Col " + i.ToString()));
            }
            VStack.Children.Add(headerrow);
            for (int i = 0; i <= 10; i++){
                List<CellObject> cells = new List<CellObject>();
                for (int j = 0; j <= 10; j++)
                {
                    if (i % 2 == 0) cells.Add(new CellObject(i, j, true));
                    else cells.Add(new CellObject(i, j, false));
                }
                RowObject newrow = new RowObject(cells);
                VStack.Children.Add(newrow);
            }
        }
    }
    public class RowObject : StackPanel
    {
        public List<CellObject> cells { get; set; }
        public RowObject(List<CellObject> cells)
        {
            this.cells = cells;
            this.Orientation = Orientation.Horizontal;
            foreach(CellObject cell in this.cells)
            {
                this.Children.Add(cell);
            }
        }
    }
    public class CellObject : CheckBox
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Int64 Id { get; set; }
        public bool Value { get { return this.IsChecked.Value; } set { this.IsChecked = value; } }
        public Int64 IdLck { get; set; }
        public Int64 IdKey { get; set; }
        public SolidColorBrush BackgroundColor { get; set; }
        public CellObject(int row, int column, bool value)
        {
            this.Value = value;
            this.Row = row;
            this.Column = column;
            this.Checked += OnChecked;
            this.Unchecked += OnUnchecked;
            if (this.Value)
            {
                this.Background = new SolidColorBrush(Colors.Red);
                this.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
        private void OnUnchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You unchecked Row: " + this.Row.ToString() + " Column: " + this.Column.ToString());
        }
        private void OnChecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You checked Row: " + this.Row.ToString() + " Column: " + this.Column.ToString());
        }
    }
    public class KeyGroup
    {
        public String Name { get; set; }
        public KeyGroup(String name)
        {
            this.Name = name;
        }
    }
    public class ColumnHeaderRow : StackPanel
    {
        public ColumnHeaderRow(List<KeyGroup> keygroups)
        {
            this.Orientation = Orientation.Horizontal;
            foreach (KeyGroup kg in keygroups)
            {
                TextBox tb = new TextBox();
                tb.Text = kg.Name;
                this.Children.Add(tb);
            }
        }
    }
