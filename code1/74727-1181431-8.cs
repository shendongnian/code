    public static class MyAlgoFactory
    {
        private static Dictionary<string, IMySortingAlgorithms> m_dict;
        /// <summary>
        /// For all the assmeblies in the current application domain,
        /// Get me the object of all the Types that implement IMySortingAlgorithms
        /// </summary>
        static MyAlgoFactory()
        {
            var type = typeof(IMySortingAlgorithms);
            m_dict = AppDomain.CurrentDomain.GetAssemblies().
                SelectMany(s => s.GetTypes()).
                Where(p => {return type.IsAssignableFrom(p) && p != type;}).
                Select(t=> Activator.CreateInstance(t) as IMySortingAlgorithms).
                ToDictionary(i=> i.Name);
        }
    
        public static IMySortingAlgorithms GetSortingAlgo(string name)
        {
            return m_dict[name];
        }
    }
