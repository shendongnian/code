        private static Dictionary<string, List<object>> m_dCommandFuncs = new Dictionary<string, List<object>>
        {
            { "foo", new List<object>{1, 3, (Command)CommandFoo}},
            { "bar", new List<object>{2, 2, (Command)CommandBar}}
        };
