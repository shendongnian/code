    static int? ToInt32OrNull(string s)
    {
        int value;
        return (Int32.TryParse(s, out value)) ? value : null;      
    }
    // ...
    var str = "123;3344;4334;12"; 
    var list = new List<int>();
    list.AddRange(str.Split(';').Select(ToInt32OrNull).Where(i => i != null));
