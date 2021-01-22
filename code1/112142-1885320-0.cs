    protected override void OnLocationChanged(EventArgs e)
        {
            if (this.Location.X > Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - 544)
            {
                this.SetBounds(0, 0, 544, 312);
            }
            else if(this.Location.X < Screen.PrimaryScreen.WorkingArea.X)
            {
                this.SetBounds(0, 0, 544, 312);
            }
            if (this.Location.Y > Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - 312)
            {
                this.SetBounds(0, 0, 544, 312);
            }
            else if (this.Location.Y < Screen.PrimaryScreen.WorkingArea.Y)
            {
                this.SetBounds(0, 0, 544, 312);
            }
        }
