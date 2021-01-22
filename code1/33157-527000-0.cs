    public class SetCollection<T> : ObservableCollection<T> 
    {
        protected override void InsertItem(int index, T item)
        {
            if (Contains(item)) throw new ItemExistsException(item);
            base.InsertItem(index, item);
        }
        protected override void SetItem(int index, T item)
        {
            int i = IndexOf(item);
            if (i >= 0 && i != index) throw new ItemExistsException(item);
            base.SetItem(index, item);
        }
    }
