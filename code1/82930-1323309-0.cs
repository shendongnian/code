    Parse<T>(T parseStrategy): where T is ParseStrategy
    {
        //do some prep
        parseStrategy.Parse();
        //do something with the result;
    }
    class ParseStrategy<T>
    {
        abstract void Parse(T data);
    }
    class StringParser: ParseStrategy<String>
    {
        void Parse(String data)
        {
            //do your String parsing.
        }
    }
    class IntParser: ParseStrategy<int>
    {
        void Parse(int data)
        {
            //do your int parsing.
        }
    }
