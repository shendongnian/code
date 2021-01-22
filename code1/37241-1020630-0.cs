    static void Main(string[] args)
    {
        var parseMe = "Hello world!  1, 2, 3, DEADBEEF";
        // Don't need to write a fully generic Process() method just to parse strings -- you could 
        // combine the Split & Convert into one method and eliminate 2/3 of the type parameters
        List<string> sentences = parseMe.Split('!', str => str);
        List<int> numbers = sentences[1].Split(',', str => Int32.Parse(str, NumberStyles.AllowHexSpecifier | NumberStyles.AllowLeadingWhite));
        // Something a little more interesting
        var lettersPerSentence = Process(sentences,
                                         sList => from s in sList select s.ToCharArray(),
                                         chars => chars.Count(c => Char.IsLetter(c)));
    }
    static List<T> Split<T>(this string str, char separator, Func<string, T> Convert)
    {       
        return Process(str, s => s.Split(separator), Convert).ToList();
    }
    static IEnumerable<TOutput> Process<TInput, TData, TOutput>(TInput input, Func<TInput, IEnumerable<TData>> GetData, Func<TData, TOutput> Convert)
    {
        return from datum in GetData(input)
               select Convert(datum);
    }
