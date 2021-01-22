    public class MyClass
    {
        public List<MyClass> SubEntries { get; set; }
        public int SubEntryCount
        {
            get { return 1 + SubEntries.Sum(x => x.SubEntryCount); }
        }
    }
