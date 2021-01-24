        public List<int> FindIntersection(string[] keys, Dictionary<string, List<int>> dict)
        {
            if(keys.Length <= 1)
            {
                return null;
            }
            HashSet<int> commonElements = new HashSet<int>();
            dict[keys[0]].ForEach(x => commonElements.Add(x));
            for(int i = 1; i < keys.Length; i++)
            {
                commonElements.IntersectWith(dict[keys[i]]);
            }
            return commonElements.ToList();
        }
