    class Program
        {
            public static string xValue;
            public static string yValue;
            public static string zValue;
            static void Main(string[] args)
            {
                string s = "fdf;fdfd;fdf";
                string[] vals = s.Split(';');
                string o = "X=" + vals[0] + "  Y=" + vals[1] + "  Z=" + vals[2];
    
                xValue = vals[0];
                yValue = vals[1];
                zValue = vals[2];
    
                Console.ReadLine();
            }
    
        }
