    public class TabCollection : IList, ICollection, IEnumerable
    {
        private Foo _owner;
        public TabCollection(Foo owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");
            this._owner = owner;
        }
        public virtual int Add(Control tab)
        {
            if (tab == null)
                throw new ArgumentNullException("tab");
            this._owner.Controls.Add(tab);
            return this._owner.Controls.Count;
        }
        #region IList Members
        int IList.Add(object value)
        {
            return this.Add((Control)value);
        }
        #endregion
        // Many code has been omitted
    }
