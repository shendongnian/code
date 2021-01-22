    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool IsNumeric(this String str)
            {
                 int temp;
                 return int.TryParse(input, out temp);        
            }
        }   
    }
