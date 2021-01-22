private void myDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
{
    if (myDataGridView.EditingControl != null)
    {
        string myValue = myDataGridView.EditingControl.Text;
        e.Cancel = (!validateMyInput(myDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString());
    }
}
