    public B(IEnumerable<int> Xs, IEnumerable<int> Ys) 
    { 
        if (Xs == null || Ys == null)
           throw new ArgumentNullException( "Both collections need to be non-null" );
    
        if (Xs.Count() != Ys.Count())
           throw new ArgumentException( "Collections must be of the same size" );
        this.Points = Xs.Zip( (x,y) => new Point { X = x, Y = y } ).ToList();
    }
