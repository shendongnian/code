    private void Form_LocationChanged(object sender, EventArgs e)
    {
        if (this.Text != "Moving")
        {
            this.Text = "Moving";
        }
        tmrStoppedMoving.Start();
    }
    
    private void Timer_Tick(object sender, EventArgs e)
    {
        tmrStoppedMoving.Start();
        this.Text = "Stopped";
    }
