    public class MyClass
    {
        static class InnerCache {
            internal static readonly IList<Entry> _listCache;
            static InnerCache() {
                List<Entry> tmp  = new List<Entry>();
                //Add items to the list _listCache from XML file
                _listCache = new ReadOnlyCollection<Entry>(tmp);
            }
        }
        protected static IList<Entry> ListCache {
            get {return InnerCache._listCache;}
        }
    }
