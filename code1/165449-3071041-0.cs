    private int yDir = 1,xDir=1;
    int step = 1;
        
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (ball.Location.Y >= this.Height-50)
            yDir =   -1 ;
        if (ball.Location.X >= this.Width-50) 
            xDir= -1 ;
            
        ball.MoveBy(xDir*step,yDir*step);
        ball.Host.ElapsedTime++;
        this.Invalidate();
     }
    private void DoubleBufferedBall_Paint(object sender, PaintEventArgs e)
    {                      
            DrawOn(e.Graphics);
    }
