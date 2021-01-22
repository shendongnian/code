    public int Compute (int param1, int param2, string op) 
    {
        switch(op)
        {
            case "+": return param1 + param2;
            default: throw new NotImplementedException();
        }
    }
    public double Compute (double param1, double param2, string op) 
    {
        switch(op)
        {
            case "+": return param1 + param2;
            default: throw new NotImplementedException();
        }
    }
