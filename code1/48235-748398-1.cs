    public class ItsAlmostAStack<T>
    {
        private List<T> items = new List<T>();
    
        public void Push(T item)
        {
            items.Add(item);
        }
        public T Pop()
        {
            if (items.Count > 0)
            {
                T temp = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return temp;
            }
            else
                return default(T);
        }
        public void Remove(int itemAtPosition)
        {
            items.RemoveAt(itemAtPosition);
        }
    }
