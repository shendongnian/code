    private void MyDataGridView_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Right)
        {
            var hti = MyDataGridView.HitTest(e.X, e.Y);
            MyDataGridView.ClearSelection();
            MyDataGridView.Rows[hti.RowIndex].Selected = true;
        }
    }
    private void DeleteRow_Click(object sender, EventArgs e)
    {
        Int32 rowToDelete = MyrDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
        MyDataGridView.Rows.RemoveAt(rowToDelete);
        MyDataGridView.ClearSelection();
    }
