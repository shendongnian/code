    List<string> List1 = new List<string> { "A", "B", "C", "D" };
    List<string> List2 = new List<string> { "A", "B", "C" };
    List<string> ListTemp = new List<string>();
    foreach (string str1 in List1)
    {
         foreach (string str2 in List2)
         {
              if (str1 == str2)
              {
                   ListTemp.Add(str1);
              }
         }
     }            
    foreach (string temp in ListTemp)
    {
         List1.Remove(temp);
    }
