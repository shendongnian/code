    public static void Main(string[] args)
    {
        string [] strList = "a,b,c,d,e,f,a,a,b".Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries).Sort();
        
        foreach(string s in strList)
            Console.WriteLine(s);
    }
    public static string [] Sort(this string [] strList)
    {
        return strList.OrderBy(i => i).ToArray();
    }
