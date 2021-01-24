     /// <summary>
            /// Get Unique List sets
            /// </summary>
            /// <param name="sets"></param>
            /// <returns></returns>
            public List<List<T>> GetUniqueSets<T>(List<List<T>> sets )
            {
                List<List<T>> cache = new List<List<T>>();
    
                for (int i = 0; i < sets.Count; i++)
                {
                    // add to cache if it's empty
                    if (cache.Count == 0)
                    {
                        cache.Add(sets[i]);
                        continue;
                    }
                    else
                    {
                        //check whether current item is in the cache and also whether current item intersects with any of the items in cache
                        var cacheItems = from item in cache where (item != sets[i] && item.Intersect(sets[i]).Count() == 0) select item;
    
                        //if not add to cache
                        if (cacheItems.Count() == cache.Count)
                        {
                            cache.Add(sets[i]);
                        }
    
                    }
                }
             
    
                return cache;
    
            }
