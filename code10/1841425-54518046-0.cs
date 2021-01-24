    private void chart1_MouseDown_1(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Right))
        {
            var hitt = chart1.HitTest(e.X, e.Y);
            DataPoint dp = null;
            if (hitt.PointIndex >= 0)
            {
                dp = hitt.Series.Points[hitt.PointIndex];
            }
            ContextMenu cm = new System.Windows.Forms.ContextMenu();
            cm.MenuItems.Add("Item 1 X:" + dp.XValue, new EventHandler(Item1_Click));
            cm.Tag = dp;
            cm.Show(chart1, e.Location);
        }
    }
    private void Item1_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Item1_Click");
        DataPoint dp = (sender as MenuItem).Parent.Tag as DataPoint;
        if  (dp != null) Console.WriteLine("Y:" + dp.YValues[0]);
    }
