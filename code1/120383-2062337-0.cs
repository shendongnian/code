    class PointF {
     float x; float y;
     public PointF(float x, float y)
     {
         this.x = x;
         this.y = y;
     }
    
     public PointF(System.Drawing.PointF p) : this(p.X, p.Y) { }
     public PointF(System.Drawing.Point p) : this(p.X, p.Y) { }
    
     public static implicit operator PointF(System.Drawing.Point pt) { return new PointF(pt); }
     public static implicit operator PointF(System.Drawing.PointF pt) { return new PointF(pt); }
    }
    //....
    static void test(pointf.PointF p) {
    }
    //....
    test(new System.Drawing.PointF(1, 1));
