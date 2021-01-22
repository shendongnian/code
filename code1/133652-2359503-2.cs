    public partial class frmTestDataGridView : Form
        {
            BindingSource bindingSource1 = new BindingSource();
            List<string> datasource = new List<string>();
            public frmTestDataGridView()
            {
                InitializeComponent();
                datasource.Add("item1");
                datasource.Add("item2");
                datasource.Add("item3");
    
                bindingSource1.DataSource = datasource;
                dataGridView1.DataSource = bindingSource1;
            }
    
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int row = e.RowIndex;
                    int clmn = e.ColumnIndex;
    
                    if (e.RowIndex == dataGridView1.Rows.Count - 1)
                    {
                        bindingSource1.Add("");
                    }
                    dataGridView1.Rows[row].Cells[clmn].Value = openFileDialog1.FileName;
                }
            }
    
        }
