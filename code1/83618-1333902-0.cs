    public class MyCollection<T> : System.Collections.ObjectModel.Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            item.Parent = this;
        }
    }
