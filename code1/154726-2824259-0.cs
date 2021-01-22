    public struct myValue
    {
        int myInt;
        string MixedCaseWord;
    }
    var dictionary = new Dictionary<string, myValue>(StringComparer.OrdinalIgnoreCase);
    var key = "AaA";
    dictionary.Add(key, new MyValue { myInt = 10, MixedCaseWord = key }); 
    var correctSpelling = dictionary["AAA"].MixedCaseWord;
