      static void Main(string[] args)
      {
         try
         {
            Console.WriteLine("in the try");
            int d = 0;
            int k = 0 / d;
         }
         catch (Exception e)
         {
            Console.WriteLine("in the catch");
            throw;
         }
         finally
         {
            Console.WriteLine("In the finally");
         }
      }
