    class Program
    {
        static void Main(string[] args)
        {
            Exception ex;
            Console.WriteLine("trying 'ex'");
            if (TryHelper("ex", out ex))
            {
                Console.WriteLine("'ex' worked");
            }
            else
            {
                Console.WriteLine("'ex' failed: " + ex.Message);
                Console.WriteLine("trying 'test'");
                if (TryHelper("test", out ex))
                {
                    Console.WriteLine("'test' worked");
                }
                else
                {
                    Console.WriteLine("'test' failed: " + ex.Message);
                    throw ex;
                }
            }
        }
        private static bool TryHelper(string s, out Exception result)
        {
            try
            {
                HelperMethod(s);
                result = null;
                return true;
            }
            catch (Exception ex)
            {
                // log here to preserve stack trace
                result = ex;
                return false;
            }
        }
        private static void HelperMethod(string s)
        {
            if (s.Equals("ex"))
            {
                throw new Exception("s can be anything except 'ex'");
            }
        }
    }
