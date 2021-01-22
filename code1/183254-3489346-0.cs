    public static class DoubleExtensions
    {
        public static string ToFortranDouble(this double value)
        {
            return string.Format("0{0}", value.ToString(".#####E0"));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string fortranValue = 3147.3.ToFortranDouble();
            System.Console.WriteLine(fortranValue);
        }
    }
