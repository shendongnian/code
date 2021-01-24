    public class Triangle
    {
        public int TriangleId {get; set;}
        public int Perimeter {get; set;}
    }
    // Returns a dictionary, that each triangle has an associated list of other triangles
    // with a perimeter within a specified distance. This list may be empty.
    public Dictionary<Triangle, List<Triangle>> NearbyPerimeter(List<Triangle> primary, List<Triangle> compareList, int maxDistance)
    {
        // sort ~ O(n log n)
        // The sort is required to make an orderly advance through both lists, otherwise
        // every element needs to be compared to every other element.
        var sorteda = primary.OrderBy(x => x.Perimeter);
        // Call ToList to allow indexing with []
        var sortedb = compareList.OrderBy(x => x.Perimeter).ToList();
        
        var results = new Dictionary<Triangle, List<Triangle>>();
        
        int minCompareIndex = 0;
        int compareCount = compareList.Count;
        
        // ~ O(n)
        foreach (var tprime in sorteda)
        {
            var neighbors = new List<Triangle>();
            
            // Add logic to advance minCompareIndex based on 
            // which is larger, tprime.Perimeter or sortedb[minCompareIndex].Perimeter
            
            int i =  minCompareIndex;
            var foundMatch = false;
            
            // Until the missing logic above is added, this is O(n) x O(n) so ~ O(n^2)
            while (i < compareCount)
            {
                var second = sortedb[i];
                if (Math.Abs(tprime.Perimeter - second.Perimeter) < maxDistance)
                {
                    neighbors.Add(second);
                    
                    foundMatch = true;
                }
                else if (foundMatch)
                {
                    break;
                }
                i++;
            }
            
            results.Add(tprime, neighbors);
        }
        
        return results;
    }
