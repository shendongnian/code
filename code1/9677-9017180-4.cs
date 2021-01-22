    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplicationRound
    {
        class Program
        {
            static void Main(string[] args)
            {
                //char cDecimal = '.';    // for English cultures
                char cDecimal = ',';    // for German cultures
                List<double> l_dValue = new List<double>();
                ushort usSignificants = 5;
                l_dValue.Add(0);
                l_dValue.Add(0.000640589);
                l_dValue.Add(-0.000640589);
                l_dValue.Add(-123.405009);
                l_dValue.Add(123.405009);
                l_dValue.Add(-540);
                l_dValue.Add(540);
                l_dValue.Add(-540911);
                l_dValue.Add(540911);
                l_dValue.Add(-118.2);
                l_dValue.Add(118.2);
                l_dValue.Add(-118.18);
                l_dValue.Add(118.18);
                l_dValue.Add(-118.188);
                l_dValue.Add(118.188);
    
                foreach (double d in l_dValue)
                {
                    Console.WriteLine("d = Maths.Round('" +
                        cDecimal + "', " + d + ", " + usSignificants +
                        ") = " + Maths.Round(
                        cDecimal, d, usSignificants));
                }
                Console.Read();
            }
        }
    }
