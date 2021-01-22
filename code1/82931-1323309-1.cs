    class SomeParser
    {
        void Parse<T>(ParseStrategy<T> parseStrategy, T data)
        {
            //do some prep
    
            parseStrategy.Parse(data);
            //do something with the result;
        }
    }
    class ParseStrategy<T>
    {
        abstract void Parse(T data);
    }
    class StringParser: ParseStrategy<String>
    {
        override void Parse(String data)
        {
            //do your String parsing.
        }
    }
    class IntParser: ParseStrategy<int>
    {
        override void Parse(int data)
        {
            //do your int parsing.
        }
    }
    //use it like so
    [Test]
    public void ParseTest()
    {
        var someParser = new SomeParser();
        someParser.Parse(new StringParser(), "WHAT WILL THIS PARSE TO");
    }
