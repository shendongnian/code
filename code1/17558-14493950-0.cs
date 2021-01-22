        private double Rounding(double d, int digits)
        {
            int neg = 1;
            if (d < 0)
            {
                d = d * (-1);
                neg = -1;
            }
            
            int n = 0;
            if (d > 1)
            {
                while (d > 1)
                {
                    d = d / 10;
                    n++;
                }
                d = Math.Round(d * Math.Pow(10, digits));
                d = d * Math.Pow(10, n - digits);
            }
            else
            {
                while (d < 0.1)
                {
                    d = d * 10;
                    n++;
                }
                d = Math.Round(d * Math.Pow(10, digits));
                d = d / Math.Pow(10, n + digits);
            }
            
            return d*neg;
        }
       private void testing()
       {
           double a = Rounding(1230435.34553,3);
           double b = Rounding(0.004567023523,4);
           double c = Rounding(-89032.5325,2);
           double d = Rounding(-0.123409,4);
           double e = Rounding(0.503522,1);
           Console.Write(a.ToString() + "\n" + b.ToString() + "\n" + 
               c.ToString() + "\n" + d.ToString() + "\n" + e.ToString() + "\n");
       }
