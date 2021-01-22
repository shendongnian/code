    public partial class DGVCheckBoxTesting : Form
    {
       
        private const int MAX_CHECKS = 5;
        public DGVCheckBoxTesting()
        {
            InitializeComponent();
            this.dataGridView1.Columns.Add("IntColumn", "IntColumn");
            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn { Name = "BoolColumn" });
            for (int i = 0; i <= 10; i++)
            {
                this.dataGridView1.Rows.Add(i, false);
            }
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellContentDoubleClick);
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ValidateCheckBoxState(e);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ValidateCheckBoxState(e);
        }
        private void ValidateCheckBoxState(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1) //bool column
            { return; }
            this.dataGridView1.EndEdit();
            bool value = (bool)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            int counter = 0;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null && (bool)row.Cells[1].Value)
                {
                    counter++;
                }
            }
            if (counter > MAX_CHECKS)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                this.dataGridView1.EndEdit();
            }
        }
        
    }
