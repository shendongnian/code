    class Program
    {
        static void Main(string[] args)
        {
            string guid1 = "936DA01F-9ABD-4d9d-80C7-02AF85C822A8";
            string guid2 = "936DA01F-9ABD-4d9d-80C7-02AF85C822A";
            Console.WriteLine("guid1: {0}", guid1.IsGuid());
            Console.WriteLine("guid2: {0}", guid2.IsGuid());
            Console.ReadLine();
        }
    }
    public static class GuidUtility
    {
        /// <summary>
        /// Determines if string is legitimate GUID
        /// </summary>       
        public static Boolean IsGuid(this String s)
        {
            string pattern = @"^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(s);
        }
    }
}
