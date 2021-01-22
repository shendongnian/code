    private void Form_Paint(object sender, PaintEventArgs e)
    {
       e.Graphics.Clear();  // clear any and all circles being drawn
    
       if (CircleIsVisible)
       {
         e.Graphics.DrawEllipse( ... ); // OR, DrawImage( ) as in your example
       }
    }
    
    private void MouseDoubleClick (object sender, MouseEventArgs e)
    {
       CircleIsVisible = true;
       Invalidate();  // triggers Paint event
    }
