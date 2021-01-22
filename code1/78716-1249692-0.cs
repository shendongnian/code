    public class Foo : ICollection
    {
        protected abstract int Count
        {
            get;
        }
        int ICollection.Count
        {
            get
            {
                return Count;
            }
        }
    }
