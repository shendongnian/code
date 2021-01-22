    double[] d1=new double[5];
    double[] d2=new double[3];
    double[] dTotal = new double[d1.Length + d2.Length];
    
    d1.CopyTo(dTotal , 0);
    d2.CopyTo(dTotal , d1.Length);
