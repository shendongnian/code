    class Program
    {
        static void Main(string[] args)
        {
            string returnValue = null;
           new Thread(
              () =>
              {
                  returnValue =test() ; 
              }).Start();
            Console.WriteLine(returnValue);
            Console.ReadKey();
        }
        public static string test()
        {
            return "Returning From Thread called method";
        }
    }
