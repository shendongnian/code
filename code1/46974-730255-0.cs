        static void Main(string[] args)
        {
            try
            {
                Method2();
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace.ToString());
                Console.ReadKey();
            }
        }
        private static void Method2()
        {
            try
            {
                Method1();
            }
            catch (Exception ex)
            {
                //throw ex resets the stack trace Coming from Method 1 and propogates it to the caller(Main)
                throw ex;
            }
        }
        private static void Method1()
        {
            try
            {
                throw new Exception("Inside Method1");
            }
            catch (Exception)
            {
                throw;
            }
        }
