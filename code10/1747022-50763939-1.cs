    private void MyDataGridView_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Right)
        {
            var hti = MyDataGridView.HitTest(e.X, e.Y);
            MyDataGridView.ClearSelection();
            MyDataGridView.Rows[hti.RowIndex].Selected = true;
            dataGridView1.CurrentCell =dataGridView1.Rows[hti.RowIndex].Cells[0];
        }
    }
