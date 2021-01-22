    public static class Program
    {
        private static void Main(string[] args)
        {
            double[] numbers =
            {
                3000, 3300, 3333, 30000, 300000, 3000000, 3000003, 0.253, 0.0253, 0.00253, -0.253003
            };
            foreach (var num in numbers)
            {
                Console.WriteLine($"{num} ==> {num.Humanize()}");
            }
            Console.ReadKey();
        }
        public static string Humanize(this double number)
        {
            string[] suffix = {"f", "a", "p", "n", "μ", "m", string.Empty, "k", "M", "G", "T", "P", "E"};
            var absnum = Math.Abs(number);
            int mag;
            if (absnum < 1)
            {
                mag = (int) Math.Floor(Math.Floor(Math.Log10(absnum))/3);
            }
            else
            {
                mag = (int) (Math.Floor(Math.Log10(absnum))/3);
            }
            var shortNumber = number/Math.Pow(10, mag*3);
            return $"{shortNumber:0.###}{suffix[mag + 6]}";
        }
    }
