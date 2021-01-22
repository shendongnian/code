    static void Main(string[] args)
    {
        if (args.Length == 0) { args = new string[] { "3", "43", "6" }; }
        var scanner = args.Select<string, Func<Type, Object>>((string s) => {
                return (Type t) =>
                ((IConvertible)s).ToType(t, System.Globalization.CultureInfo.InvariantCulture); 
            }).GetEnumerator();
        while (scanner.MoveNext())
        {
            Console.Write("{0} ", scanner.Current(typeof(int)));
        }            
    }
