    dgv_tabla.MouseMove += Dgv_tabla_MouseMove;
    private void Dgv_tabla_MouseMove(object sender, MouseEventArgs e)
    {
        int index = dgv_tabla.Columns["Remove"].Index;
        DataGridView.HitTestInfo info = dgv_tabla.HitTest(e.X, e.Y);
        if (info.ColumnIndex == index && info.RowIndex >= 0)
            dgv_tabla.Cursor = Cursors.Hand;
        else
            dgv_tabla.Cursor = Cursors.Default;
    }
