    private void btn_Record_Click(object sender, EventArgs e)
    {
        points = new List<Point>();
        index = 0;
        tt = new Timer()
        { Interval = 50, Enabled = true };
        tt.Tick += (ss, ee) => 
        {
            if (!points.Any() || points.Last() != Control.MousePosition) 
               points.Add(Control.MousePosition); 
        };
    }
