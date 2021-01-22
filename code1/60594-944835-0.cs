    public class SpecialList<T> : List<DataInfo<T>>
    {
        public void Add(string description, Func<T, object> func)
        {
            base.Add(new DataInfo<T>(description, func));
        }
    }
