    public static class DoubleExtensions
    {
        public static string ToFortranDouble(this double value)
        {
            return value.ToString("\\0.#####E0");
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
