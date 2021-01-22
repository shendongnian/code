    //Global variables;
    private bool _dragging = false;
    private Point _offset;
    private Point _start_point=new Point(0,0);
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
       _dragging = true;  // _dragging is your variable flag
       _start_point = new Point(e.X, e.Y);
    }
    
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
       _dragging = false; 
    }
    
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
      if(_dragging)
      {
         Point p = PointToScreen(e.Location);
         Location = new Point(p.X - this._start_point.X,p.Y - this._start_point.Y);     
      }
    }
