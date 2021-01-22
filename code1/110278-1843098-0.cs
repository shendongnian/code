    public class MyClass
    {
        static class InnerCache {
            internal static readonly List<Entry> _listCache;
            static InnerCache() {
                _listCache = new List<Entry>();
                //Add items to the list _listCache from XML file
            }
        }
        protected static List<Entry> ListCache {
            get {return InnerCache._listCache;}
        }
    }
