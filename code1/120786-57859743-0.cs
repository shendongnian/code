    public static string GetCommonStartingPath(string[] keys)
            {
                Array.Sort(keys, StringComparer.InvariantCulture);
                string a1 = keys[0], a2 = keys[keys.Length - 1];
                int L = a1.Length, i = 0;
                while (i < L && a1[i] == a2[i])
                {
                    i++;
                }
                
                string result = a1.Substring(0, i);
    
                return result;
            }
