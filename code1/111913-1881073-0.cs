    private void Form1_MouseLeave(object sender, EventArgs e)
    {
       if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
       {
        this.Opacity = 1.0;
       }
    else
    {
        int loopctr = 0;
        for (loopctr = 100; loopctr >= 5; loopctr -= 10)
        {
            this.Opacity = loopctr / 99.0;
            this.Refresh();
            Thread.Sleep(100);
        }
    }
   }
