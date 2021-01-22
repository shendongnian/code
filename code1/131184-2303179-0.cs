    struct Pair
    {
        public Pair(DateTime t, int v)
        {
            date = t;
            value = v;
        }
        public DateTime date;
        public int value;
    }
    
        ....
    
        List<Pair> pairs = new List<Pair>();
    
    
        pairs.Add(new Pair(DateTime.Now, 100));
        pairs.Add(new Pair(DateTime.Now, 200));
    
        ....
        // Sort using the time.
        pairs.Sort(delegate(Pair pair1, Pair pair2) {
                               return  pair1.date.CompareTo( pair2.date);
                            }
                  );
    
        // Do binary search.
        int index = pairs.BinarySearch(new Pair(dateToSearch, 0), 
                                       delegate(Pair pair1, Pair pair2) { 
                                           return pair1.date.CompareTo(pair2.date); 
                                       });
    
        if (index >= 0) {
            // Found the element!
            return pairs[index].value;
        }
    
        // If not found, List.BinarySearch returns the complement of the index where the
        // element should have been.
        index = ~index;
        
        // This date search for is larger than any
        if (index == pairs.Count) {
            //
        }
        
        // The date searched is smaller than any in the list.
        if (index == 0) {
        }
    
        // Otherwise return average of elements at index and index-1.
        return (pairs[index-1].value + pairs[index].value)/2;
