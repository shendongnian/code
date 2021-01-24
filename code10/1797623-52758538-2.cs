        public static void DoStuff()
        {
            var one = new SomeClass(10);
            var two = new SomeClass(200);
            var three = new SomeClass(10); //same value as object "one"
            var myComparer = new SomeClassComparer();
            var myDictionary = new Dictionary<SomeClass, object>(myComparer);
            myDictionary.Add(one, "Some Data");
            myDictionary.Add(two, new[] { 1, 2, 3, 4 } );
            // causes exceptions even if InitializationTime differs because of SomeClass.ImportantValue comparison 
            myDictionary.Add( three, new List<object>() );
        }
        public class SomeClass
        {
            public int ImportantValue { get; set; }
            public DateTime InitializationTime { get; set; }
            public SomeClass(int value)
            {
                ImportantValue = value;
                //every object gets its "unique" InitializationTime
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
                //calculate a hash code from data that represents the identity of the objects data
                return (obj.ImportantValue).GetHashCode();
            }
        }
