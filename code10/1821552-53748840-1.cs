       public class CollectionFilter2
        {
            public List<List<int>> FilterDoubles( List<List<int>> combinaties )
            {
                // First part: collects collisions for each value in the list
                // This is done using a dictionary that holds all concerned lists in front of each value
                var hitDictionary = new Dictionary<int, List<List<int>>>();
                foreach ( var comb in combinaties.Where( c => c.Count > 0 ) )
                {
                    foreach ( var value in comb )
                    {
                        if ( hitDictionary.TryGetValue( value, out var list ) == false )
                        {
                            list = new List<List<int>>();
                            hitDictionary[value] = list;
                        }
    
                        list.Add( comb );
                    }
                }
    
                var result = new List<List<int>>();
    
                // Second part: search for lists for which one value has no collision
                foreach ( var comb in combinaties.Where( c => c.Count > 0 ) )
                {
                    var count = comb.Count;
    
                    // Initialize the intersection
                    var inter = hitDictionary[comb[0]];
    
                    // Makes the intersection for each value (or quit if the intersection is one list)
                    for ( var i = 1 ; i < count && inter.Count > 1 ; i++ )
                        inter = inter.Intersect( hitDictionary[comb[i]] ).ToList();
    
                    // If only one intersection, this is a result
                    if ( inter.Count == 1 )
                        result.Add( comb );
                }
    
                return result;
            }
        }
