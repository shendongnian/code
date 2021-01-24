    public class SMAPIException : Exception
    {
        public SMAPIException(string str) : base(ChangeString(str))
        {
            /*   Since SMAPIException derives from Exceptions we can use 
             *   all public properties of Exception
             */
            Console.WriteLine(base.Message);
        }
        private static string ChangeString(string message)
        {
            return $"Exception is: \"{message}\"";
        }
    }
