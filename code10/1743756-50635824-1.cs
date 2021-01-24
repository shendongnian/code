        bool found = TryGet(newIds, "Name", 1, out int result);
        public bool TryGet(Dictionary<string, Dictionary<int, int>> dicts, string name, int num, out int val)
        {
            val = -1;
            if (dicts.TryGetValue(name, out Dictionary<int, int> dict))
            {
                if (dict.TryGetValue(num, out int res))
                {
                    val = res;
                    return true;
                }
                return false;
            }
            return false;
        }
