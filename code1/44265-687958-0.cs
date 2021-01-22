    class Test
    {
        Dictionary<int, string> entities;
        public string GetEntity(int code)
        {
            string val;
            if (entities.TryGetValue(code, out val))
                return val;
            else
                return null;
        }
    }
