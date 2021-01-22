    private void dataGridView1_Click(object sender, EventArgs e)
    {
        MouseEventArgs args = (MouseEventArgs)e;
        DataGridView dgv = (DataGridView)sender;
        DataGridView.HitTestInfo hit = dgv.HitTest(args.X, args.Y);
        if (hit.Type == DataGridViewHitTestType.TopLeftHeader)
        {
            // do something here
        }
    }
