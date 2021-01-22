    using System;
    namespace ConsoleApplicationRound
    {
        class Program
        {
            static void Main(string[] args)
            {
                //char cDecimal = '.';    // for English cultures
                char cDecimal = ',';    // for German cultures
                double[] a_dValue = new double[9];
                ushort usSignificants = 5;
                a_dValue[0] = 0;
                a_dValue[1] = 0.000640589;
                a_dValue[2] = -0.000640589;
                a_dValue[3] = -123.405009;
                a_dValue[4] = 123.405009;
                a_dValue[5] = -540;
                a_dValue[6] = 540;
                a_dValue[7] = -540911;
                a_dValue[8] = 540911;
                foreach (double d in a_dValue)
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
