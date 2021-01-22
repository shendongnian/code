    public sealed class DataInfoListBuilder<T> : IEnumerable
    {
        private readonly List<DataInfo<T>> list = new List<DataInfo<T>>();
        public void Add(string description, Func<T, object> function)
        {
             list.Add(DataInfo.Create<T>(description, function));
        }
        public List<DataInfo<T>> Build()
        {
            return list;
        }
        public IEnumerator GetEnumerator()
        {
            throw new InvalidOperationException
                ("IEnumerator only implemented for the benefit of the C# compiler");
        }
    }
