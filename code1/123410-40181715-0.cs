    class Program
    {
        static void Main(string[] args)
        {
            foreach (var x in new[] { "asdf", })
            {
                System.Console.WriteLine(x);
                // error CS1656: Cannot assign to 'x' because it is a 'foreach iteration variable'
                x = "food";
            }
        }
    }
