    public static class ListExt
    {
        public static T Find<T>( this IList<T> list, string name ) where T : IListable 
        {
            return list.Where( x => x.Name == name ).SingleOrDefault();
        }
    }
    // we can now do this:
    var listObjects = new List<SomeType>() { /* populate collection */ };
    var item = listObjects.Find( "nameToFind" );
