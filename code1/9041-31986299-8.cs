    public static class ArrayEx
    {
    
        public static string JoinArray<T>(this T[] inputTypeArray, string separator)
        {
            string strRetValue = null;
            System.Collections.Generic.List<string> ls = new System.Collections.Generic.List<string>();
            
            for (int i = 0; i < inputTypeArray.Length; ++i)
            {
                string str = System.Convert.ToString(inputTypeArray[i], System.Globalization.CultureInfo.InvariantCulture);
                
                if (!string.IsNullOrEmpty(str))
                { 
                    // SQL-Escape
                    // if (typeof(T) == typeof(string))
                    //    str = str.Replace("'", "''");
                    
                    ls.Add(str);
                } // End if (!string.IsNullOrEmpty(str))
            
            } // Next i 
            
            strRetValue= string.Join(separator, ls.ToArray());
            ls.Clear();
            ls = null;
            
            return strRetValue;
        }
    }
