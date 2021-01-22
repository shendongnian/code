    public class ChainedListItem<T>
    {
        private ChainedListItem<T> _nextItem;
        T _content;
    
        public ChainedListItem<T> NextItem
        {
            get { return _nextItem; }
            set { _nextItem = value; }
        }
    
        public T Content
        {
            get { return _content; }
            set { _content = value; }
        }
    
        public ChainedListItem<T> Add(T content)
        {
            _nextItem = new ChainedListItem<T>();
            _nextItem.Content = content;
            return _nextItem;
        }
    
        public void Dump()
        {
            ChainedListItem<T> current = this;
            while ((current = current.NextItem) != null)
            {
                Console.WriteLine(current._content);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ChainedListItem<int> chainedList = new ChainedListItem<int>();
            chainedList.Add(1).Add(2).Add(3);
            chainedList.Dump();        
        }
    }
