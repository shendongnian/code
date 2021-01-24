    class Program {
        static readonly CultureInfo USEnglish = new CultureInfo("en-US");
        static void Main(string[] args) {
            var value = "$291.00";
            var valueAsDecimal = decimal.Parse(value, System.Globalization.NumberStyles.Any, USEnglish);
            Console.WriteLine(valueAsDecimal);
            Console.ReadLine();
        }
    }
