    public class ExtendedList<T> : List<T>
    {
        public new void Add(T t)
        {
            int index = base.BinarySearch(t);
            if (index < 0)
            {
                base.Insert(~index, t);
            }
    
        }
    }
