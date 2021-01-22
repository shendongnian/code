    public class Exception
    {
        public static void Main()
        {
            try
            {
                SomeMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
        public static void SomeMethod()
        {
            try
            {
                // This exception will be lost
                throw new Exception("Exception in try block");
            }
            finally
            {
                throw new Exception("Exception in finally block");
            }
        }
    } 
