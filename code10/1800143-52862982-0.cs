    class Program
    {
        static void Main(string[] args)
        {
            var input = "%fdfd678dfdfdfdfdfdfdfdffd";
            var result = Regex.Replace(input, "^.{7}", input.Substring(0,6));
            Console.WriteLine($"result = {result}");
        }
    }
