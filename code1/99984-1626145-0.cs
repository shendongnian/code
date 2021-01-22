    public class ListDemo<T> : IList<T>
    {
        private List<T> list = new List<T>(); // Internal list
        public void Add(T item)
        {
           // Do your pre-add logic here
           list.Add(item); // add to the internal list
           // Do your post-add logic here
        }
        // Implement all IList<T> methods, just passing through to list, such as:
    }
