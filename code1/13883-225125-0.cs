    public interface IMudObject
    {
        IMudObject Container { get; set; }
        /* etc */
    }
    public class MudContainer<T> : Collection<T>, IMudObject
        where T : IMudObject
    {
        
        public IMudObject Container { get; set; }
        protected override void ClearItems()
        {
            foreach (T item in this)
            {
                RemoveAsContainer(item);
            }
            base.ClearItems();
        }
        protected override void InsertItem(int index, T item)
        {
            SetAsContainer(item);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            RemoveAsContainer(this[index]);
            base.RemoveItem(index);            
        }
        protected override void SetItem(int index, T item)
        {
            RemoveAsContainer(this[index]);
            SetAsContainer(item);
            base.SetItem(index, item);
        }
        void RemoveAsContainer(T item)
        {
            if (item != null && ReferenceEquals(item.Container, this))
            {
                item.Container = null;
            }
        }
        void SetAsContainer(T item)
        {
            if (item.Container != null)
            {
                throw new InvalidOperationException("Already owned!");
            }
            item.Container = this;
        }
    }
