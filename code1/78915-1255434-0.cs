        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var map = new Dictionary<A, R>();
            var mapSync = new Dictionary<A, object>();
            return a =>
            {
                R value;
                object sync = null;
                bool calc = false;
                bool wait = false;
                lock (map)
                {
                    if (!map.TryGetValue(a, out value))
                    {
                        //its not in the map
                        if (!mapSync.TryGetValue(a, out sync))
                        {
                            //not currently being created
                            sync = new object();
                            mapSync[a] = sync;
                            calc = true;
                        }
                        else
                        {
                            calc = false;
                            wait = true;
                        }
                    }
                }
                if(calc)
                {
                    lock (sync)
                    {
                        value = f(a);
                        lock (map)
                        {
                            map.Add(a, value);
                            mapSync.Remove(a);
                        }
                        Monitor.PulseAll(sync);
                        return value;
                    }
                }
                else if (wait)
                {
                    lock (sync)
                    {
                        while (!map.TryGetValue(a, out value))
                        {
                            Monitor.Wait(sync);
                        }
                        return value;
                    }
                }
                lock (map)
                {
                    return map[a];
                }
            };
        }
