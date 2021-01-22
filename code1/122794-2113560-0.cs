    private SortableBindingList<Names> _names;
    public Form1()
    {
        InitializeComponent();
            
        _names = new SortableBindingList<Names>();
        _names.Add(new Names() { Name = "joe" });
        _names.Add(new Names() { Name = "pete" });
        DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
        col1.DataPropertyName = "Name";
        dataGridView1.Columns.Add(col1);
        dataGridView1.DataSource = _names;            
    }
    private void button1_Click(object sender, EventArgs e)
    {             
       _names.Add(new Names(){Name = "kevin"});
       dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
    } 
    public class Names
    {
        public string Name { get; set; }
    }
