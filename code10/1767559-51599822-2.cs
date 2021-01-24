    Dictionary<string, int> dic = GetObjectCount(list);
    
    //Print to Console
    foreach(string s in dic.Keys)
    {
       Console.WriteLine(s + " has a count of: " + dic[s]);
    }
