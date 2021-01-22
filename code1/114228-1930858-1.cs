    #pragma warning disable 0162
    namespace ConsoleApplication4
    {
      public class Program
      {
        public const bool something = false;
        static void Main(string[] args)
        {
            if (something) { Console.WriteLine(" Not something" ); }
        } 
     }
