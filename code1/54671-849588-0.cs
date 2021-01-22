    class Cache
        {
            Dictionary<object, object> cache = new Dictionary<object, object>();
    
            /// <summary>
            /// Keeps up with the most recently read items.
            /// Items at the end of the list were read last. 
            /// Items at the front of the list have been the most idle.
            /// Items at the front are removed if the cache capacity is reached.
            /// </summary>
            List<object> priority = new List<object>();
            public Type Type { get; set; }
            public Cache(Type type)
            {
                this.Type = type;
    
                //TODO: register this cache with the manager 
                
            }
            public object this[object key]
            { 
                get 
                {
                    lock (this)
                    {
                        if (!cache.ContainsKey(key)) return null;
                        //move the item to the end of the list                    
                        priority.Remove(key);
                        priority.Add(key);
                        return cache[key];
                    }
                }
                set 
                {
                    lock (this)
                    {
                        if (Capacity > 0 && cache.Count == Capacity)
                        {
                            cache.Remove(priority[0]);
                            priority.RemoveAt(0);
                        }
                        cache[key] = value;
                        priority.Remove(key);
                        priority.Add(key);
    
                        if (priority.Count != cache.Count)
                            throw new Exception("Capacity mismatch.");
                    }
                }
            }
            public int Count { get { return cache.Count; } }
            public int Capacity { get; set; }
    
            public void Clear()
            {
                lock (this)
                {
                    priority.Clear();
                    cache.Clear();
                }
            }
        }
