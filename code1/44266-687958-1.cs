    class Test
    {
        Dictionary<int, string> entities;
        public string GetEntity(int code)
        {
            // java's get method returns null when the key has no mapping
            // so we'll do the same
            string val;
            if (entities.TryGetValue(code, out val))
                return val;
            else
                return null;
        }
    }
