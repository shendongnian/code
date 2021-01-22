            /// <summary>
        /// If h contains v then return true, else add v to h and return false.
        /// Thread safe on h.
        /// </summary>
        /// <param name="h"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        bool TestAndAdd(HashSet<string> h, string v)
        {
            lock(h)
            {
                if(h.Contains(v))
                {
                    return true;
                }
                h.Add(v);
                return false;
            }
        }
