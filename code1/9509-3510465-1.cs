    public class MyEncoding
    {
        public sealed class EncodingIndexer
        {
            public Encoding this[string name]
            {
                get { return Encoding.GetEncoding(name); }
            }
            public Encoding this[int codepage]
            {
                get { return Encoding.GetEncoding(codepage); }
            }
        }
        private static EncodingIndexer StaticIndexer;
        public static EncodingIndexer Items
        {
            get { return StaticIndexer ?? (StaticIndexer = new EncodingIndexer()); }
        }
    }
