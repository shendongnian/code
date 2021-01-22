    public class SomeClass
    {
        private readonly int[] _someThings;
    
        public SomeClass()
        {
            _someThings = new int[4];
        }
    
        public SomeClass(int[] someThings)
        {
            _someThings = someThings;
        }
    
        public int[] SomeThings
        {
            get { return _someThings; }
        }
    }
...
            var anObject = new SomeClass(new [] {4, 8});
