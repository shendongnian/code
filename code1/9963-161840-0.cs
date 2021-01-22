    // NB:  A bool is the return value. 
    //      This makes it possible to put this beast in if statements.
    public bool TryCalculatePoint(... out Point result) { }
    public Point CalculatePoint(...)
    {
       Point result;
       if(!TryCalculatePoint(... out result))
           throw new BogusPointException();
       return result;
    }
