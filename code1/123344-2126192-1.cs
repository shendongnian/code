        public static IEnumerable<T> Top<T>(this IEnumerable<T> values)
        {
            List<T> ret = new List<T>();
            int max = -1;
            foreach (var val in values.Distinct())
            {
                int count = values.Count(t => t.Equals(val));
                if (count >= max)
                {
                    if (count > max)
                    {
                        ret.Clear();
                        max = count;
                    }
                    ret.Add(val); //stacks equivalent count, if applicable
                }
            }
            return ret;
        }
