        public static double digits(double x)
        {
            double n = Math.Floor(x);
            double d;
            if (d >= 1.0)
            {
                for (d = 1; n >= 1.0; ++d)
                {
                    n = n / 10;
                }
            }
            else
            {
                for (d = 1; n < 1.0; ++d)
                {
                    n = n * 10;
                }
            }
            return d;
        }
        public static double guess(double x)
        {
            double output;
            double d = Program.digits(x);
            if (d % 2 == 0)
            {
                output = 6*Math.Pow(10, (d - 2) / 2);
            }
            else
            {
                output = 2*Math.Pow(10, (d - 1) / 2);
            }
            return output;
        }
