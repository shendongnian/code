     MyDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
     
     // for cell selection
     private void MyDataGridView_MouseDown(object sender, MouseEventArgs e)
     {
      if(e.Button == MouseButtons.Right)
        {
           var hit = MyDataGridView.HitTest(e.X, e.Y);
           MyDataGridView.ClearSelection();
         
           // cell selection
           MyDataGridView[hit.ColumnIndex,hit.RowIndex].Selected = true;
       }
    }
    private void DeleteRow_Click(object sender, EventArgs e)
    {
       int rowToDelete = MyDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
       MyDataGridView.Rows.RemoveAt(rowToDelete);
       MyDataGridView.ClearSelection();
    }
