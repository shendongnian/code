    bool ThisLabelCanMove;
    Point LabelMousePosition = Point.Empty;
    private void MovableLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            LabelMousePosition = e.Location;
            ThisLabelCanMove = true;
        }
    }
    private void MovableLabel_MouseUp(object sender, MouseEventArgs e)
    {
        ThisLabelCanMove = false;
    }
    private void MovableLabel_MouseMove(object sender, MouseEventArgs e)
    {
        if (ThisLabelCanMove)
        {
            Label label = sender as Label;
            Point LabelNewLocation = new Point(label.Left + (e.Location.X - LabelMousePosition.X),
                                               label.Top + (e.Location.Y - LabelMousePosition.Y));
            LabelNewLocation.X = (LabelNewLocation.X < pictureBox1.Left) ? pictureBox1.Left : LabelNewLocation.X;
            LabelNewLocation.Y = (LabelNewLocation.Y < pictureBox1.Top) ? pictureBox1.Top : LabelNewLocation.Y;
            LabelNewLocation.X = (LabelNewLocation.X + label.Width > pictureBox1.Right) ? label.Left : LabelNewLocation.X;
            LabelNewLocation.Y = (LabelNewLocation.Y + label.Height > pictureBox1.Bottom) ? label.Top : LabelNewLocation.Y;
            label.Location = LabelNewLocation;
        }
    }
