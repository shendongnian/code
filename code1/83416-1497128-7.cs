    class Utility<T> where T : ICloneable
    {
        static public IEnumerable<T> CloneList(List<T> tl)
        {
            foreach (T t in tl)
            {
                yield return (T)t.Clone();
            }
        }
    }
