        static IEnumerable<Func<int>> GetFuncs()
        {
            List<Func<int>> list = new List<Func<int>>();
            foreach (var i in Enumerable.Range(1, 20))
            {
                int i_local = i;
                list.Add(() => i_local);
            }
            return list;
        }
