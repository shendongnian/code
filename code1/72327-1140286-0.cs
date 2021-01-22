    private void DrawScene(Point mouseLocation)
    {
         myGraphics.Clear(Color.White)
         myGraphics.DrawEllipse(skyBluePen, mouseLocation.X - 150, mouseLocation.Y - 150, 300, 300);
         myDrawingSurface.Refresh(); //myDrawingSurface can be a Form or a PictureBox or whatever you'd like.  Normally, you'd only Invalidate areas that have changed
    }
    
    private void myDrawingSurface_MouseMove(object sender, MouseEventArgs e)
    {
        DrawScene(e.Location);
    }
    
    private void myDrawingSurface_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawImage(myBitmap, 0, 0); //Can't remember the exact signature
    }
