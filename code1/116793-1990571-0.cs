    public delegate bool CutoffDateDelegate( out DateTime cutoffDate );
    // using lambda syntax:
    CutoffDateDelegate d1 = 
        (out DateTime dt) => { dt = DateTime.Now; return true; };
   
    // using anonymous delegate syntax:
    CutoffDateDelegate d2 = 
        delegate( out DateTime dt ) { dt = DateTime.Now; return true; }
