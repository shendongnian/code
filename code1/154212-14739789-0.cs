        public static Dictionary<TSource, Int32> MergeIntDictionary<TSource>( this ICollection<Dictionary<TSource, Int32>> source )
        {
            return source.Aggregate( ( cur, next ) => cur.Concat( next )
                .GroupBy( o => o.Key )
                .ToDictionary( item => item.Key, item => item.Sum( o => o.Value ) ) );
        }
