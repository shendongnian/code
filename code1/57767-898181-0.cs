    public class LimitedCollection<T> : Collection<T>
    {
        private int _maxitems = 500;
    
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            TrimData(); /* Delete old data if lenght too long */
        }
        
        private void TrimData()
        {
            int num = Math.Max(0, base.Count - _maxitems);
            while (num > 0)
            {
                base.RemoveAt(0);
                num--;
            }
        }
    }
