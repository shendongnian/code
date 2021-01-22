    public class MyClassCollection
    {
        // Private object for locking
        private readonly object syncObject = new object(); 
        private readonly List<MyObject> list = new List<MyObject>();
        public this[int index]
        {
            get { return list[index]; }
            set
            {
                 lock(syncObject) { 
                     list[index] = value; 
                 }
            }
        }
        public void Add(MyObject value)
        {
             lock(syncObject) {
                 list.Add(value);
             }
        }
        public void Clear()
        {
             lock(syncObject) {
                 list.Clear();
             }
        }
        // Do any other methods you need, such as remove, etc.
        // Also, you can make this class implement IList<MyObject> 
        // or IEnumerable<MyObject>, but make sure to lock each 
        // of the methods appropriately, in particular, any method
        // that can change the collection needs locking
    }
