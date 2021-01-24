    Dictionary<string, object> fooDict = new Dictionary<string, object>();
    
    fooDict.Add("A", "AXA"); // in my case I put 2 nested object to value field
    fooDict.Add("B", "BXA"); 
    
    var serializedObject = JsonConvert.SerializeObject(fooDict);
        
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\xxx\result.txt", true))
    {
        file.WriteLine(serializedObject);
    }
