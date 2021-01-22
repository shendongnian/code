    class Values {
        ulong Value1 {get;set;}
        ulong Value2 {get;set;}
    }
    
    var theDictionary=new Dictionary<int, Values>;
    
    theDictionary.Add(1, new Values {Value1=2, Value2=3});
