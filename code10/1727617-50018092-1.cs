        List<Point> points = null;
        Timer tt = null;
        int index = 0;
        private void btn_Record_Click(object sender, EventArgs e)
        {
            points = new List<Point>();
            index = 0;
            tt = new Timer()
            { Interval = 50, Enabled = true };
            tt.Tick += (ss,ee) => { points.Add(Control.MousePosition); };
        }
        private void btn_Replay_Click(object sender, EventArgs e)
        {
            tt.Stop();
            tt = new Timer()      { Interval = 50, Enabled = true };
            tt.Tick += (ss,ee) => {
                if (index < points.Count)
                { System.Windows.Forms.Cursor.Position =  points[index++]; }
                else tt.Stop();
            };
        }
