    var colSums = 
       from col in array.Pivot()
       select col.Sum();
----------
     public static class LinqExtensions {
        public static IEnumerable<IEnumerable<T>> Pivot<T>( this IList<T[]> array ) {
            for( int c = 0; c < array[ 0 ].Length; c++ )
                yield return PivotColumn( array, c );
        }
        private static IEnumerable<T> PivotColumn<T>( IList<T[]> array, int c ) {
            for( int r = 0; r < array.Count; r++ )
                yield return array[ r ][ c ];
        }
    }
