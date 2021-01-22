    public class Class1
    {
        public delegate void GetDataDelegate(string url);
        private event GetDataDelegate GetData;
        public Class1(GetDataDelegate getData)
        {
            GetData += getData;
        }
        //blah blah blah
    }
'
