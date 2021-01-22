    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("False", false);
            dataGridView1.Rows.Add("True", true);
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >-1 && dataGridView1.Rows[e.RowIndex].Cells[1].IsInEditMode)
            {
                dataGridView1.EndEdit();
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Value =
                   dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); 
            }
        }
    }
