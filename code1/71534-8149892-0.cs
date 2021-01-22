    namespace System
    {
        public static class BaseTypesExtensions
        {
            /// <summary>
            /// Just a simple wrapper to simplify the process of splitting a string using another string as a separator
            /// </summary>
            /// <param name="s"></param>
            /// <param name="pattern"></param>
            /// <returns></returns>
            public static string[] Split(this string s, string separator)
            {
                return s.Split(new string[] { separator }, StringSplitOptions.None);
            }
    
    
        }
    }
