    public PointF(float x = 0, float y = 0)
    {
        this.x = x;
        this.y = y;
    }
    public PointF(System.Drawing.PointF p) : this(p.X, p.Y) { }
    public PointF(System.Drawing.Point p) : this(p.X, p.Y) { }
    
    //add this:
    public static implicit operator PointF(System.Drawing.Point pt) 
    { return new PointF(pt); }
