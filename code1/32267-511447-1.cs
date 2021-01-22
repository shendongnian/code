        public static void AddNewElement<T>(IList<T> l, int i, string s)
        {
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { i, s });
            l.Add(obj);
        }
