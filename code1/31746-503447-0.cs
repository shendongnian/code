    static void Main(string[] args)
    {
        var isFalse = "t".IsInt();
        var isTrue = "123".IsInt();
        var isAlsoFalse = "123.1".IsInt();
    
    }
    
    static bool IsInt(this IEnumerable<char> s)
    {
        return s.All(x => char.IsNumber(x));
    }
 
