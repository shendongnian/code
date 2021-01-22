    class Sample<T>
    {
        public static Func<T, bool> Identity = x => true;
        public static Func<T, bool> CreateExpression(string value)
        {
            if(value == "foo")
                return Identity;
            return x => value.Length % 2 == 0;
        }
    }
    class Test
    {
        public void DoTest()
        {
            Debug.Assert(Sample<string>.CreateExpression("foo") == Sample<string>.Identity);
        }
    }
