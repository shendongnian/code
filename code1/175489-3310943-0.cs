    public class Tester<T, R> where T : IEnumerable<R>
    {
        private T _item;
        public T Item
        {
            get { return _item; }
            set { _item = value; }
        }
    
        public string GetItemAsString()
        {
            IEnumerable<R> items = _item as IEnumerable<R>;
            if (items != null)
            {
                StringBuilder str = new StringBuilder();
                int count = 0;
                foreach (R item in items)
                {
                    str.Append(count++ > 0 ? "," : String.Empty);
                    str.Append(item.ToString());
                }
    
                return str.ToString();
    
            }
            return null;
        }
    }
