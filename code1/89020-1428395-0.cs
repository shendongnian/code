    using System;
    public static class Class1
    {
        public static void Main()
        {
            Console.WriteLine(RenderCompareStatus());
        }
        public static string RenderCompareStatus()
        {
            String id = "test";
            bool isFound = Found(id);
            return "Test: " + isFound;
        }
        public static bool Found(string id)
        {
            return false;
        }
    }
