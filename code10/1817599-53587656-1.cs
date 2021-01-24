    public partial class LookupForm : Form
    {
    	public object data = new object();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    	{
    		data = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
    		this.DialogResult = DialogResult.OK;
    		this.Close();
    	}
    }
