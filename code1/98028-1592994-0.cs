    //Global variables;
    Private bool Dragging = false;
    Private Point offset;
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
       Dragging = true;  // Dragging is your variable flag
    }
    
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
       Dragging = false; 
    }
    
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if(Dragging)
      {
         Point currentPos = PointToScreen(e.Location);
         Location = new Point(currentPos.X - offset.X, currentPos.Y - offset.Y);
      }
    }
