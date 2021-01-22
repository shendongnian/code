    public static IEnumerable<IEnumerable<T>> Group<T>(IEnumerable<T> items)
        where T : IEquatable<T>
    {
        IList<IList<T>> groups = new List<IList<T>>();
        foreach (T t in items)
        {
            bool foundGroup = false;
		
            foreach (IList<T> group in groups)
            {
                Debug.Assert(group.Count() >= 1);
                if (group[0].Equals(t))
                {
                    group.Add(t);
                    foundGroup = true;
                    break;
                }
            }
            if (!foundGroup)
            {
                IList<T> newGroup = new List<T>() { t };
                groups.Add(newGroup);
            }
        }
        foreach (IList<T> group in groups)
        {
            yield return group;
        }
    }
