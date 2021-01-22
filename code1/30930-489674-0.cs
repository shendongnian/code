            DataTable table = new DataTable();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                table.Columns.Add("Name");
                table.Columns.Add("Age", typeof(int));
                table.Rows.Add("Alex", 26);
                table.Rows.Add("Jim", 36);
                table.Rows.Add("Bob", 34);
                table.Rows.Add("Mike", 47);
                table.Rows.Add("Joe", 61);
    
                this.dataGridView1.DataSource = table;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                table.Columns.Add("Height", typeof(int));
                foreach (DataRow row in table.Rows)
                {
                    row["Height"] = 100;
                }
            }
  
            private void button3_Click(object sender, EventArgs e)
            {
                GridViewer g = new GridViewer { DataSource = table };
                g.ShowDialog();
            }
            public partial class GridViewer : Form //just has a DataGridView on it
            {
                public GridViewer()
                {
                InitializeComponent();
                }
    
                public object DataSource
                {
                    get { return this.dataGridView1.DataSource; }
                    set { this.dataGridView1.DataSource = value; }
                }
            }
