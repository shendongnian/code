    public class CollectionFilter4
    {
        class Temp
        {
            public List<int> Combinaty; // Original list
            public List<int> Values; // Distinct values
        }
    
        public List<List<int>> FilterDoubles( List<List<int>> combinaties )
        {
            // Generate distinct values
            var temps = combinaties.Where( c => c.Count > 0 ).Select( c => new Temp() { Combinaty = c, Values = c.Distinct().ToList() } ).ToList();
    
            // Collision dictionary (same as previous code)
            var hitDictionary = new Dictionary<int, List<Temp>>();
            foreach ( var temp in temps )
            {
                foreach ( var value in temp.Values )
                {
                    if ( hitDictionary.TryGetValue( value, out var list ) == false )
                    {
                        list = new List<Temp>();
                        hitDictionary[value] = list;
                    }
    
                    list.Add( temp );
                }
            }
    
            // Ascending sort on collision count (this has an impact on the intersection later, as we want to keep the shortest anyway)
            temps.ForEach( t => t.Values.Sort( ( a, b ) => hitDictionary[a].Count.CompareTo( hitDictionary[b].Count ) ) );
    
            var result = new List<Temp>();
    
            foreach ( var temp in temps )
            {
                var values = temp.Values;
                var count = values.Count;
    
                var inter = new HashSet<Temp>(); // Create a hashset from the first value
                foreach ( var t in hitDictionary[values[0]] ) inter.Add( t );
    
                for ( var i = 1 ; i < count && inter.Count > 1 ; i++ )
                {
                    // Rewritten intersection
                    inter = Intersect( hitDictionary[values[i]], inter );
                }
    
                if ( inter.Count == 1 )
                    result.Add( temp );
            }
    
            return result.Select( r => r.Combinaty ).ToList();
        }
    
        // Same as original linq code except but optimized for this case
        static HashSet<TSource> Intersect<TSource>( IEnumerable<TSource> first, HashSet<TSource> second )
        {
            var result = new HashSet<TSource>();
    
            foreach ( TSource element in first )
                if ( second.Remove( element ) ) result.Add( element );
    
            return result;
        }
    }
