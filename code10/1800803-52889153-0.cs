    Dictionary<string, string> dic = new Dictionary<string, string>();
    dic.Add("10", "a");
    dic.Add("20", "b");
    
    // Ouput
    foreach (var key in dic.Keys)
       Console.WriteLine(key + " "+ dic[key]);
    
    // Change 
    dic["10"] = "C";
    dic["20"] = "D";
    // Ouput    
    foreach (var key in dic.Keys)
       Console.WriteLine(key + " " + dic[key]);
    
