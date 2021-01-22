    public class LimitedList<T> : List<T>
    {
        private int _maxitems = 500;
    
        public new void Add(T value) /* Adding a new Value to the buffer */
        {
            base.Add(value);
            TrimData(); /* Delete old data if length too long */
        }
    
        private void TrimData()
        {
            int num = Math.Max(0, base.Count - _maxitems);
            base.RemoveRange(0, num);
        }
    }
