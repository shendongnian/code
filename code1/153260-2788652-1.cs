    double[] d1 = new double[5];
    double[] d2 = new double[3];
    double[] dTotal = new double[d1.length + d2.length];
    
    Array.Copy(d1, 0, dTotal, 0, d1.Length);
    Array.Copy(d2, 0, dTotal, d1.Length, d2.Length);
