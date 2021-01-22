        static List<T> SortList<T>(List<T> list, string column)
        {
            foreach (PropertyInfo p in typeof(T).GetProperties())
            {
                if (p.Name == column)
                {
                    return list.OrderBy(c => c.GetType().GetProperty(p.Name).GetValue(c, null)).ToList();
                }
            }
            return list;
        }
