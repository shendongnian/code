    private void btn_Replay_Click(object sender, EventArgs e)
    {
        index = 0;
        tt = new Timer() { Interval = 50, Enabled = true };
        tt.Tick += (ss, ee) =>
        {
            if (index < points.Count)
              { System.Windows.Forms.Cursor.Position =  points[index++]; }
            else tt.Stop();
    }
