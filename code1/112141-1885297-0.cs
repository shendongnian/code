    protected override OnMove(EventArgs e)
    {
        if (Screen.PrimaryScreen.WorkingArea.Contains(this.Location))
        {
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
    }
