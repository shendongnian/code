    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn) dataGridView1.Columns[1];
            DataGridViewComboBoxColumn col2 = (DataGridViewComboBoxColumn)dataGridView1.Columns[2];
            List<string> items = new List<string>(){"B", "C", "E", "A"};
            col.DataSource = items;
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col2.DataSource = items;
            col2.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Rows.Add(new string[] {"A", "B", "C", "D"});
            dataGridView1.Rows.Add(new string[] { "B", "C", "C", "F" });
            dataGridView1.Rows.Add(new string[] { "C", "B", "A", "A" });
        }        
    }
