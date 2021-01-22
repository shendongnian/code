        static void Main(string[] args)
        {
            try
            {
                principalMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine("Test : " + e.Message);
            }
            Console.Read();
        }
        public static void principalMethod()
        {
            try
            {
                throw new Exception("Primary");
            }
            catch (Exception ex1)
            {
                try
                {
                    methodThatCanCrash();
                }
                catch
                {
                    throw new Exception("Cannot deinitialize", ex1);
                }
            }
        }
        private static void methodThatCanCrash()
        {
            throw new NotImplementedException();
        }
