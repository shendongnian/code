     /******************************************************/
        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = ",", bool header = true)
        {
           FieldInfo[] fields = typeof(T).GetFields();
           PropertyInfo[] properties = typeof(T).GetProperties();
           string str1;
           string str2;
           if(header)
           {
              str1 = String.Join(separator, fields.Select(f => f.Name).Concat(properties.Select(p => p.Name)).ToArray());
              str1 = str1 + Environment.NewLine;
              yield return str1;
           }
           foreach(var o in objectlist)
           {
              //regex is to remove any misplaced returns or tabs that would
              //really mess up a csv conversion.
              str2 = string.Join(separator, fields.Select(f => (Regex.Replace(Convert.ToString(f.GetValue(o)), @"\t|\n|\r", "") ?? "").Trim())
                 .Concat(properties.Select(p => (Regex.Replace(Convert.ToString(p.GetValue(o, null)), @"\t|\n|\r", "") ?? "").Trim())).ToArray());
              str2 = str2 + Environment.NewLine;
              yield return str2;
           }
        }
