    private static string[] NoDuplicate(string[] inputArray)
    {
         List<string> stringList = new List<string>();
         foreach (string s in inputArray)
         {
               if (!stringList.Contains(s))
               {
                    stringList.Add(s);
               }
         }
         return stringList.ToArray();
    }
