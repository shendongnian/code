    private Point ptMouseDown=new Point();
    
    protected override void MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ptMouseDown = new Point(e.X, e.Y);
        }
    }
    
    protected override void MouseMove(object sender, MouseEventArgs e)
    {
        if (_Offset != Point.Empty)
        {
            Pointf[] ptArr=new Pointf[]{this.Location};
            Point Diff=new Point(e.X-ptMouseDown.X,e.Y-ptMouseDown.Y);
            Matrix mat=new Matrix();
            mat.Translate(Diff.X,Diff.Y);
            mat.TransFromPoints(ptArr);
            this.Location=ptArr[0];
        }
    }   
    
    protected override void MouseUp(object sender, MouseEventArgs e)
    {
        _Offset = Point.Empty;
    }
