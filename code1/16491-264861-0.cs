    static void Main()
    {
        string name = "";
        int value = 0;
        Foo("whatever",
            x => { name = x; },
            x => { value = int.Parse(x); });    
    }
    // yucky; wash eyes after reading...
    static void Foo(string query, params Action<string>[] actions)
    {
        string[] results = Bar(query); // the actual query
        int len = actions.Length < results.Length ? actions.Length : results.Length;
        for (int i = 0; i < len; i++)
        {
            actions[i](results[i]);
        }
    }
