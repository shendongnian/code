     public partial class Form1 : Form
        {
            DataTable table = new DataTable();
            public Form1()
            {
                InitializeComponent();
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                this.dataGridView1.ColumnAdded += new DataGridViewColumnEventHandler(dataGridView1_ColumnAdded);
            }
    
            void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
            {
                Console.WriteLine("Column added");
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                
                table.Columns.Add("Name");
                table.Columns.Add("Age", typeof(int));
    
                table.Rows.Add("John", 27);
                this.FlipSelectionMode();
                this.dataGridView1.DataSource = table;
                this.FlipSelectionMode();
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                this.FlipSelectionMode();
                table.Columns.Add("Height",typeof(int));
                table.Rows[0]["Height"] = 60;
                this.FlipSelectionMode();
            }
    
            private void FlipSelectionMode()
            {
                this.dataGridView1.SelectionMode = this.dataGridView1.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect ? DataGridViewSelectionMode.CellSelect : DataGridViewSelectionMode.ColumnHeaderSelect;
            }
        }
