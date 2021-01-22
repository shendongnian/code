    public class TabCollection : StateManagedCollection
    {
        public Tab this[int index]
        {
            get { return (Tab)((IList)this)[index]; }
        }
        public int Add(Tab tab)
        {
            if (tab == null)
                throw new ArgumentNullException("tab");
            return ((IList)this).Add(tab);
        }
        // You have to write Insert, Remove and RemoveAt methods.
        protected override void SetDirtyObject(object o)
        {
            ((Tab)o).SetDirty();
        }
    }
