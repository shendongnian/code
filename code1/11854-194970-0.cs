    namespace StringExtensionMethods
    {
        public static class StringExtension
        {
            public static bool Contains(this string[] stringarray, string pat)
            {
                bool result = false;
    
                foreach (string s in stringarray)
                {
                    if (s == pat)
                    {
                        result = true;
                        break;
                    }
                }
    
                return result;
            }
        }
    }
