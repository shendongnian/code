        class Program
        {
           static void Main(string[] args)
           {
              string msg;
              Console.WriteLine(string.Format("GetRandomNuber returned: {0}{1}", GetRandomNumber(out msg), msg) == "" ? "" : "An error has occurred: " + msg);
           }
           static int GetRandomNumber(out string errorMessage)
           {
             int result = 0;
             try
             {
                errorMessage = "";
                int test = 0;
                result = 3/test;
                return result;
             }
             catch (Exception ex)
             {
                errorMessage = ex.Message;
                throw ex;
             }
             finally
             {
                Console.WriteLine("finally block!");
             }
            
           }
        }
