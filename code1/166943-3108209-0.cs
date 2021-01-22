    public interface IInnerType
    {
        Int32 Id { get; set; }
    }
    public class Container
    {
        public Container()
        {
            Items = new InnerTypeCollection();
            Items.Add(new InnerType() { Id = 1 });
            Items.Add(new InnerType() { Id = 2 });
            Items.Add(new InnerType() { Id = 3 });
            Items.Add(new InnerType() { Id = 4 });
            Items.Add(new InnerType() { Id = 5 });
        }
        public InnerTypeCollection Items { get; protected set; }
        class InnerType : IInnerType
        {
            public InnerType()
            { }
            public Int32 Id { get; set; }
        }
        public class InnerTypeCollection : ICollection<IInnerType>
        {
            List<IInnerType> Items { get; set; }
            public InnerTypeCollection()
            {
                Items = new List<IInnerType>();
            }
            public void Add(IInnerType item)
            {
                if (!(item is InnerType))
                {
                    throw new ArgumentException("item must be of InnerType");
                }
                Items.Add(item);
            }
            public void Clear()
            {
                Items.Clear();
            }
            public bool Contains(IInnerType item)
            {
                return Items.Contains(item);
            }
            public void CopyTo(IInnerType[] array, int arrayIndex)
            {
                Items.CopyTo(array, arrayIndex);
            }
            public int Count
            {
                get { return Items.Count; }
            }
            public bool IsReadOnly
            {
                get { return (Items as ICollection<IInnerType>).IsReadOnly; }
            }
            public bool Remove(IInnerType item)
            {
                return Items.Remove(item);
            }
            public IEnumerator<IInnerType> GetEnumerator()
            {
                return Items.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return Items.GetEnumerator();
            }
        }
    }
