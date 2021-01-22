    public partial class UserControlWithComboBoxColumnDataGrid : UserControl
    {
        private Dictionary<int, string> _Dictionary;
        private ObservableCollection<MyItem> _MyItems;
        public UserControlWithComboBoxColumnDataGrid() {
          _Dictionary = new Dictionary<int, string>();
          _Dictionary.Add(1,"A");
          _Dictionary.Add(2,"B");
          _MyItems = new ObservableCollection<MyItem>();
          dataGridMyItems.AutoGeneratingColumn += DataGridMyItems_AutoGeneratingColumn;
          dataGridMyItems.ItemsSource = _MyItems;
        }
    private void DataGridMyItems_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                var desc = e.PropertyDescriptor as PropertyDescriptor;
                var att = desc.Attributes[typeof(ColumnNameAttribute)] as ColumnNameAttribute;
                if (att != null)
                {
                    if (att.Name == "My Combobox Item") {
                        var comboBoxColumn =  new DataGridComboBoxColumn {
                            DisplayMemberPath = "Value",
                            SelectedValuePath = "Key",
                            ItemsSource = _ApprovalTypes,
                            SelectedValueBinding =  new Binding( "Bazinga"),   
                        };
                        e.Column = comboBoxColumn;
                    }
                    
                }
            }
    }
    public class MyItem {
        public string Name{get;set;}
        [ColumnName("My Combobox Item")]
        public int Bazinga {get;set;}
    }
      public class ColumnNameAttribute : Attribute
        {
            public string Name { get; set; }
            public ColumnNameAttribute(string name) { Name = name; }
    }
