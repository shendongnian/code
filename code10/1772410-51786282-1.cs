    private void control_MouseClick(object sender, MouseEventArgs e)
    {
            Control control = sender as Control;
            int posX = control.Location.X;
            int posY = control.Location.Y;
            //Add e.X respectivly e.Y if you want to add the mouse position within the control that generated the event.
            while (control.Parent != null)
            {
                control = control.Parent;
                posX += control.Location.X;
                posY += control.Location.Y;
            }
            ((Label)sender).Text = "X: " + posX + " Y: " + posY;
    }
