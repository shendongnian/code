    static class SomeClass
    {
        static readonly ReadOnlyDictionary<string,int> SOME_MAPPING 
            = new ReadOnlyDictionary<string,int>(
                new Dictionary<string,int>()
                {
                    { "One", 1 },
                    { "Two", 2 }
                }
            )
    }        
