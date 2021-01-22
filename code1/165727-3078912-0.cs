    private void button1_Click(object sender, EventArgs e)
    {
      if (!animationTimer.Enabled)
      {
        animationTimer.Interval = 10;
        animationTimer.Start();
      }
    }
    private int _animateDirection = 1;
    private void animationTimer_Tick(object sender, EventArgs e)
    {
      button1.Location = new Point(button1.Location.X, button1.Location.Y + _animateDirection);
      
      if (button1.Location.Y == 0 || button1.Location.Y == 100)
      {
        animationTimer.Stop();
        _animateDirection *= -1; // reverse the direction
      }
    }
