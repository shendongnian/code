    public class FixedSizeList<T> : Collection<T>
    {
        public int MaxItems {get;set;}
        protected override void InsertItem(int index, T item){
            base.InsertItem(index, item);
   
            while (base.Count > MaxItems) {
                base.RemoveItem(0);
            }
        }
    }
