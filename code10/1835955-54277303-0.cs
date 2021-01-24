    //declare a dic of string, int
    Dictionary<string, int> dic = new Dictionary<string,int>
    
    //iterate loop 
    foreach (var i in lst)
    {
         if (dic.ContainsKey(i))
         {
             dic[i]++;
         }
         else
         {
             dic.Add(i, 1);
         }
    }
