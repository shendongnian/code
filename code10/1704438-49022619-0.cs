    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            TimeSpan a = TimeSpan.FromMinutes(2);
            TimeSpan b = TimeSpan.FromMinutes(1.95);
            TimeSpan c = TimeSpan.FromMinutes(1.97);
            TimeSpan d = TimeSpan.FromMinutes(1.99);
            
            Console.WriteLine(GetRealMinutesDouble(a));   // out - 2
            Console.WriteLine(GetRealMinutesDouble(b));   // out - 1,57
            Console.WriteLine(GetRealMinutesDouble(c));   // out - 1,58
            Console.WriteLine(GetRealMinutesDouble(d));   // out - 1,59
        }
        public static double GetRealMinutesDouble(TimeSpan a )
        {
            var aSecondsPart = a.TotalMinutes - Math.Truncate(a.TotalMinutes);// Cut the decimal part which shows the seconds
            var aSecondsPartInRealSeconds = Math.Round(aSecondsPart*60/100*100)/100;// convert them to the interval 0-59
            return Math.Truncate(a.TotalMinutes)+aSecondsPartInRealSeconds;//add them back
        }
    }
