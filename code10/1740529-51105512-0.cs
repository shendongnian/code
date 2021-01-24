    public static double[] filter(double[] b, double[] a, double[] x)
    {
       // normalize if a[0] != 1.0. TODO: check if a[0] == 0
       if(a[0] != 1.0)
       {
           a = a.Select(el => el / a[0]).ToArray();
           b = b.Select(el => el / a[0]).ToArray();
       }
       double[] result = new double[x.Length];
       result[0] = b[0] * x[0];
       for (int i = 1; i < x.Length; i++)
       {
           result[i] = 0.0;
           int j = 0;
           if ((i < b.Length) && (j < x.Length))
           {
               result[i] += (b[i] * x[j]);
           }
           while(++j <= i)
           {
                int k = i - j;
                if ((k < b.Length) && (j < x.Length))
                {
                    result[i] += b[k] * x[j];
                }
                if ((k < x.Length) && (j < a.Length))
                {
                    result[i] -= a[j] * result[k];
                }
            }
        }
        return result;
    }
