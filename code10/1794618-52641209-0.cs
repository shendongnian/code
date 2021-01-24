    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "0.402777777777778";
            double outVal = 0;
            if (double.TryParse(input1, out outVal))
            {
                var t = DoubleToTimeSpan(outVal);
                Console.WriteLine("Input: " + input1);
                Console.WriteLine("Output: " + t);
            }
            else
            {
                //Your string is in time format
            }
            Console.WriteLine();
            string input2 = "0.59056712962963";
            if (double.TryParse(input2, out outVal))
            {
                var t = DoubleToTimeSpan(outVal);
                Console.WriteLine("Input: " + input2);
                Console.WriteLine("Output: " + t);
            }
            else
            {
                //Your string is in time format
            }
            Console.ReadLine();
        }
        public static TimeSpan DoubleToTimeSpan(double dValue)
        {
            int seconds_in_a_day = 86400;
            int iDays = (int)dValue;
            double dSeconds = Math.Floor(seconds_in_a_day * (dValue -
            iDays));
            return new TimeSpan(iDays, 0, 0, (int)dSeconds, 0);
        }
    }
    
