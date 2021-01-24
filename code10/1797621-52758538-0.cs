        public static void DoStuff()
        {
            var one = new SomeClass(10);
            var two = new SomeClass(200);
            var three = new SomeClass(10);
            var myComparer = new SomeClassComparer();
            var myDictionary = new Dictionary<SomeClass, object>(myComparer)
            {
                { one, "Some Data" },
                { two, new[] { 1, 2, 3, 4 } },
                // causes exceptions because of SomeClass.ImportantValue comparison even when InitializationTime differs
                { three, new List<object>() } 
            };
        }
        public class SomeClass
        {
            public int ImportantValue { get; set; }
            public DateTime InitializationTime { get; set; }
            public SomeClass(int value)
            {
                ImportantValue = value;
                InitializationTime = DateTime.Now;
            }
        }
        public class SomeClassComparer : IEqualityComparer<SomeClass>
        {
            public bool Equals(SomeClass x, SomeClass y)
            {
                //do comparison of data that represents the identity of the objects data
                return x.ImportantValue.Equals(y.ImportantValue);
            }
            public int GetHashCode(SomeClass obj)
            {
                return (obj.ImportantValue).GetHashCode();
            }
        }
