    using System;
    using System.Windows.Media;
    class NearestConsoleColor
    {
        static ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;
    
            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }
    
        static void Main()
        {
            foreach (var pi in typeof(Colors).GetProperties())
            {
                var c = (Color)ColorConverter.ConvertFromString(pi.Name);
                var cc = ClosestConsoleColor(c.R, c.G, c.B);
    
                Console.ForegroundColor = cc;
                Console.WriteLine("{0,-20} {1} {2}", pi.Name, c, Enum.GetName(typeof(ConsoleColor), cc));
            }
        }
    }
