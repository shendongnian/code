    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool IsInteger(this String input)
            {
                 int temp;
                 return int.TryParse(input, out temp);        
            }
        }   
    }
