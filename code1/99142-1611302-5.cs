    public class ExtendedList<T> : List<T>
    {
        public new void Add(T t)
        {
            base.Add(t);
            base.Sort();
        }
    } 
