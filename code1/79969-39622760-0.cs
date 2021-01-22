     public static bool HasDuplicates<T>(IList<T> items)
        {
            Dictionary<T, bool> mp = new Dictionary<T, bool>();
            for (int i = 0; i < items.Count; i++)
            {
                if (mp.ContainsKey(items[i]))
                {
                    return true; // has duplicates
                }
                mp.Add(items[i], true);
            }
            return false; // no duplicates
        }
