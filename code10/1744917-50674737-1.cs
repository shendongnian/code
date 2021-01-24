    private Dictionary<Source,TransactionType> PopulateSource()
    {
    Dictionary<Source,TransactionType> classified = new Dictionary<Source,TransactionType>();
    //populate dictionary by iterating using
     var keys = Enum.GetValues(typeof(Source)); 
     var values = Enum.GetValues(typeof(TransactionType));
    you can just iterate through keys if your keys and values in enum are in order .
    
    return classified ;
    }
    
    public void TestSourceTransaction()
    {
    TransactionType transType;
    var classifieds = PopulateSource();
    var key  = GetSourceType(inputDescription);//you need to write a method to get key from desc based on regex or string split options.
    if(classifieds.ContainsKey(key))
              classifieds[key].Value;
    else
             throw new InvalidTypeException("Source type undefined");
    }
