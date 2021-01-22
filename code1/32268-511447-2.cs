        public static void AddNewElement2(IList l, int i, string s)
        {
            if (l == null || l.Count == 0)
                throw new ArgumentNullException();
            object obj = Activator.CreateInstance(l[0].GetType(), new object[] { i, s });
            l.Add(obj);
        }
