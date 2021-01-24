    private void SimulationTimer_Tick(object sender, EventArgs e)
    {
      System.Drawing.Point current =new System.Drawing.Point();
      current =  Ball.Location;
      Ball.Location = new Point(Ball.Location.X + x, Ball.Location.Y - y);        
      PictureBox dot = new PictureBox();
      dot.BackColor = Color.Red;
      dot.Location = current;
      dot.Height= 5;
      dot.Width = 5;
      this.Controls.Add(dot);
    }
