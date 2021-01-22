    public class TabCollection : IList, ICollection, IEnumerable
    {
        private TabMenu _tabMenu;
        public TabCollection(TabMenu tabMenu)
        {
            if (tabMenu == null)
                throw new ArgumentNullException("tabMenu");
            this._tabMenu = tabMenu;
        }
        public virtual int Add(Tab tab)
        {
            if (tab == null)
                throw new ArgumentNullException("tab");
            this._tabMenu.Controls.Add(tab);
            return (int)this._tabMenu.Controls.Count - 1;
        }
        int IList.Add(object value)
        {
            return this.Add((Tab)value);
        }
        // You have to write other methods and properties as Add.
    }
