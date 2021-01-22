    var someCollection = new []{ 5, 2, 8, 9, 0, 1, 3, 12, 4 };
    var fifthItem = someCollection.NthItem( 5 );
    public static class NthExtensions {
        public static T NthItem( this IEnumerable<T> coll, int n ) {
            return coll.OrderBy( x => x ).Skip(m-1).First();
        }
    }
