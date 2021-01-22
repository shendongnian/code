    public class ListDemo<T> : Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            // Your add condition ...
            if (!this.Any(x => ...))
                base.InsertItem(index, item);
        }
    }
