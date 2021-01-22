    //Global variables;
    private bool Dragging = false;
    private Point offset;
    private Point _startPoint=new Point(0,0);
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
       Dragging = true;  // Dragging is your variable flag
       _startPoint = new Point(e.X, e.Y);
    }
    
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
       Dragging = false; 
    }
    
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if(Dragging)
      {
         Point p = PointToScreen(e.Location);
         Location = new Point(p.X - this._start_point.X,p.Y - this._start_point.Y);     
      }
    }
