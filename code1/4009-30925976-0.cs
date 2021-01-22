        /// <summary>
        /// Takes k elements from the next n elements at random, preserving their order.
        /// 
        /// If there are fewer than n elements in items, this may return fewer than k elements.
        /// </summary>
        /// <typeparam name="TElem">Type of element in the items collection.</typeparam>
        /// <param name="items">Items to be randomly selected.</param>
        /// <param name="k">Number of items to pick.</param>
        /// <param name="n">Total number of items to choose from.
        /// If the items collection contains more than this number, the extra members will be skipped.
        /// If the items collection contains fewer than this number, it is possible that fewer than k items will be returned.</param>
        /// <returns>Enumerable over the retained items.
        /// 
        /// See http://stackoverflow.com/questions/48087/select-a-random-n-elements-from-listt-in-c-sharp for the commentary.
        /// </returns>
        public static IEnumerable<TElem> TakeRandom<TElem>(this IEnumerable<TElem> items, int k, int n)
        {
            var r = new FastRandom();
            var itemsList = items as IList<TElem>;
            if (k >= n || (itemsList != null && k >= itemsList.Count))
                foreach (var item in items) yield return item;
            else
            {  
                // If we have a list, we can infer more information and choose a better algorithm.
                // When using an IList, this is about 7 times faster (on one benchmark)!
                if (itemsList != null && k < n/2)
                {
                    // Since we have a List, we can use an algorithm suitable for Lists.
                    // If there are fewer than n elements, reduce n.
                    n = Math.Min(n, itemsList.Count);
                    // This algorithm picks K index-values randomly and directly chooses those items to be selected.
                    // If k is more than half of n, then we will spend a fair amount of time thrashing, picking
                    // indices that we have already picked and having to try again.   
                    var invertSet = k >= n/2;  
                    var positions = invertSet ? (ISet<int>) new HashSet<int>() : (ISet<int>) new SortedSet<int>();
                    var numbersNeeded = invertSet ? n - k : k;
                    while (numbersNeeded > 0)
                        if (positions.Add(r.Next(0, n))) numbersNeeded--;
                    if (invertSet)
                    {
                        // positions contains all the indices of elements to Skip.
                        for (var itemIndex = 0; itemIndex < n; itemIndex++)
                        {
                            if (!positions.Contains(itemIndex))
                                yield return itemsList[itemIndex];
                        }
                    }
                    else
                    {
                        // positions contains all the indices of elements to Take.
                        foreach (var itemIndex in positions)
                            yield return itemsList[itemIndex];              
                    }
                }
                else
                {
                    // Since we do not have a list, we will use an online algorithm.
                    // This permits is to skip the rest as soon as we have enough items.
                    var found = 0;
                    var scanned = 0;
                    foreach (var item in items)
                    {
                        var rand = r.Next(0,n-scanned);
                        if (rand < k - found)
                        {
                            yield return item;
                            found++;
                        }
                        scanned++;
                        if (found >= k || scanned >= n)
                            break;
                    }
                }
            }  
        } 
