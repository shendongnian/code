        public static class ExtensionMethods
        {
            public static bool isNumeric (this string str)
            {
                for (int i = 0; i < str.Length; i++ )
                {
                    if ((str[i] == '.') || (str[i] == ',')) continue;    //Decide what is valid, decimal point or decimal coma
                    if ((str[i] < '0') || (str[i] > '9')) return false;
                }
    
                return true;
            }
        }
