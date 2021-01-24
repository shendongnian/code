    class Program
            {
                static void Main(string[] args)
                {
                    var dd = DateTime.Now;
                    Console.WriteLine(dd.ToShortDateString().Contains("7"));
                    Console.ReadKey();
        
                }
            }
