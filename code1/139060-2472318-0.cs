    static void Main()
    {
        var bb = new List<double> { 1, 2, 3, 4 };
        var xx = new List<double> { 3, 3, 4, 5 };
        var yy = func_FIR(bb, xx);
        for (int i = 0; i < yy.Count; i++)
        {
            Console.WriteLine("y[{0}] = {1}",i,yy[i]);
        }
    }
    public static List<double> func_FIR(List<double> b, List<double> x)
    {
        //y[n]=b0x[n]+b1x[n-1]+....bmx[n-M]
        var y = new List<double>();
        int M = b.Count;
        int n = x.Count;
        double t = 0.0;
        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < M; i++)
            {
                t += b[i] * x[n - i-1];
            }
            y.Add(t);    
        }
        
        return y;
    }
