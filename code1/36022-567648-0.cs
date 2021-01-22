    public override bool Equals ( object obj )
    {
       return Equals(obj as Point2);
    }
    public bool Equals ( Point2 obj )
    {
       return obj != null && obj.X == this.X && obj.Y == this.Y ... 
       // Or whatever you think qualifies as the objects being equal.
    }
