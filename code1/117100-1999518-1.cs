    class FactoryString
        {
        static FactoryString()
        {
        private static Dictionary<string, string> dictionary = new Dictionary<string, string> 
        { 
            {"foo", "some logic here"},
            {"bar", "something else here"},
            {"raboof", "of course I need more than just Writeln"},
        };
    }
 
    public static string getString(string s)
    {
        return dictionary.Single(x => x.Key.Equals(s)).Value;
    }
}
    static void main()
    {
      Console.WriteLine(FactoryString.getString("foo"));
    }
