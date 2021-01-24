    // in class X:
    public static List<X> GetParameterListByID(int pID)
    {
        using(X x = new X())
        { 
           return x.GetParameterListByID(pID);
        }
    } 
    // and same in other classes
