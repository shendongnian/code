    private static void SmallTest()
    {
        const string templateString = @"xxx '{{ k1 | Date : ""D""  }}' yyy";
        Template.NamingConvention = new CSharpNamingConvention();
        var t = Template.Parse(templateString);
        string output = t.Render(Hash.FromDictionary(new Dictionary<string, object>(){ { "k1", "now" } }));
        Console.WriteLine("NOW --> " + output);
    }
