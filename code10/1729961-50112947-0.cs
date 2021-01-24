    public partial class MainWindow : Window
        {
            private ListView items;
            private string toParse = "1 12 13\n2 15 16\n3 9 14\n20 123 541235\n4 1234 567";
            private string toParse2 = "id value1 value2";
    
            public MainWindow()
            {
                InitializeComponent();
                items = GenerateListView(10, 10);
            }
    
            public ListView GenerateListView(int posx, int posy)
            {
                ListView listview = new ListView();
                DataTable table = new DataTable();
                GridView myGridView = new GridView();
    
                string[] columnNames = toParse2.Split(' ');
                foreach (string name in columnNames)
                {
                    table.Columns.Add(name);
    
                    GridViewColumn gvc = new GridViewColumn();
                    gvc.DisplayMemberBinding = new Binding(name);
                    gvc.Header = name;
                    gvc.Width = 100;
    
                    myGridView.Columns.Add(gvc);
                }
                string[] lines = toParse.Split('\n');
                foreach (string line in lines)
                {
                    string[] values = line.Split(' ');
    
                    if (values.Length == columnNames.Length)
                    {
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);
    
                        for (int i = 0; i < values.Length; i++)
                        {
                            row[i] = values[i];
                        }
                    }
                }
    
                listview.View = myGridView;
                listview.ItemsSource = table.DefaultView;
    
                this.grid1.Children.Add(listview);
                return listview;
            }
        }
