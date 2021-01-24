    Object result = jsExecutor.ExecuteScript(func1); // 
    var resultCollection = (ReadOnlyCollection<object>)result;       
    foreach (Dictionary<string, object> item in resultCollection)
    {
       Console.WriteLine("{0} ", item.GetType()); 
       foreach (KeyValuePair<string, object> kvp in item)
       {
         Console.WriteLine("Keys: {0} Values: {1}", kvp.Key, kvp.Value);
       }
    }
