    public static int FibNo(int n) {
        int result = 0; int No = 0; int N1 = 1;
    
        if (n< 0)
        { throw new ArguementException("number must be a positive value"); }
    
        if (n <= 1) 
        { result = n; return result; }
    
        for(int x=1; x < n; x++) 
        { result = No + N1; No = N1; N1=result; }
    
        return result;
    
    }
