    // Note: you could include "where T : class"; on the other hand
    // you might have some reason to want a NullSafeCollection<int?>
    // which you knew had no null values in.
    public class NullSafeCollection<T> : Collection<T>
    {
        protected override InsertItem(int index, T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            base.InsertItem(index, item);
        }
        // Likewise for SetItem
    }
