    private void pictureBox1_MouseDown(object sender, MouseEventArgs e) //click in box
    {
        var mouseEventArgs2 = e as MouseEventArgs;
        if (e.Button == MouseButtons.Left)
        {        
            Point[] pnts = new Point[ 1 ];
            Matrix scaleMatrix = new Matrix( 1 / zoom, 0, 0, 1 / zoom, 0, 0 ); //un scale
            pnts[0]= mouseEventArgs2.Location;
            scaleMatrix.TransformPoints( pnts );
            lines.Push(new Line { Start = pnts[0] });
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {       
        if (lines.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Point[] pnts = new Point[ 1 ];
            Matrix scaleMatrix = new Matrix( 1 / zoom, 0, 0, 1 / zoom, 0, 0 ); //un scale
            pnts[0]= e.Location;
            scaleMatrix.TransformPoints( pnts );
            lines.Peek().End = pnts[0];
            pictureBox1.Invalidate();
        }
     }
