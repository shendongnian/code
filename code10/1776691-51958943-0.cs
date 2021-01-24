    public class MyList : IEnumerable<MyItem>, IEnumerable
    {
        private List<MyItem> list = new List<MyItem>();
        public IEnumerator<MyItem> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    } 
