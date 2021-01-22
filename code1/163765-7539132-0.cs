    private void MyDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
            var hti = MyDataGridView.HitTest(e.X, e.Y);
            MyDataGridView.Rows[hti.RowIndex].Selected = true;
            MyDataGridView.Rows.RemoveAt(rowToDelete);
            MyDataGridView.ClearSelection();
            }
        }
