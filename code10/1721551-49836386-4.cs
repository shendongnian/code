    private Point setNewLocation;
    private void btn1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            setNewLocation= e.Location;
        }
    }
    private void btn1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            btn1.Left = e.X + btn1.Left - setNewLocation.X;
            btn1.Top = e.Y + btn1.Top - setNewLocation.Y;
        }
    }
