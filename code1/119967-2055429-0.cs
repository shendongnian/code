    [ParseChildren(true, "Tabs"), PersistChildren(false)]
    public partial class Foo : UserControl
    {
        private TabCollection _tabs;
        [Browsable(false), PersistenceMode(PersistenceMode.InnerProperty), MergableProperty(false)]
        public virtual TabCollection Tabs
        {
            get
            {
                if (this._tabs == null)
                    this._tabs = new TabCollection(this);
                return this._tabs;
            }
        }
    }
