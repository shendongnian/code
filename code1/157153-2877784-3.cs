    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstTimestamp = DateTime.Now;
            DateTime secondTimestamp = firstTimestamp.AddDays(1);
            /* begin composite key dictionary populate */
            Dictionary<CompositeKey, string> compositeKeyDictionary = new Dictionary<CompositeKey, string>();
            CompositeKey compositeKey1 = new CompositeKey();
            compositeKey1.Int1 = 11;
            compositeKey1.Int2 = 304;
            compositeKey1.DateTime = firstTimestamp;
            compositeKeyDictionary[compositeKey1] = "FirstObject";
            CompositeKey compositeKey2 = new CompositeKey();
            compositeKey2.Int1 = 12;
            compositeKey2.Int2 = 9852;
            compositeKey2.DateTime = secondTimestamp;
            compositeKeyDictionary[compositeKey2] = "SecondObject";
            /* end composite key dictionary populate */
            /* begin composite key dictionary lookup */
            CompositeKey compositeKeyLookup1 = new CompositeKey();
            compositeKeyLookup1.Int1 = 11;
            compositeKeyLookup1.Int2 = 304;
            compositeKeyLookup1.DateTime = firstTimestamp;
            Console.Out.WriteLine(compositeKeyDictionary[compositeKeyLookup1]);
            CompositeKey compositeKeyLookup2 = new CompositeKey();
            compositeKeyLookup2.Int1 = 12;
            compositeKeyLookup2.Int2 = 9852;
            compositeKeyLookup2.DateTime = secondTimestamp;
            Console.Out.WriteLine(compositeKeyDictionary[compositeKeyLookup2]);
            /* end composite key dictionary lookup */
        }
        struct CompositeKey
        {
            public int Int1 { get; set; }
            public int Int2 { get; set; }
            public DateTime DateTime { get; set; }
            public override int GetHashCode()
            {
                return Int1.GetHashCode() ^ Int2.GetHashCode() ^ DateTime.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (obj is CompositeKey)
                {
                    CompositeKey compositeKey = (CompositeKey)obj;
                    return ((this.Int1 == compositeKey.Int1) &&
                            (this.Int2 == compositeKey.Int2) &&
                            (this.DateTime == compositeKey.DateTime));
                }
                return false;
            }
        }
    }
