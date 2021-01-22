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
                {
                    this._tabs = new TabCollection();
                    if (base.IsTrackingViewState)
                        ((IStateManager)this._tabs).TrackViewState();
                }
                return this._tabs;
            }
        }
        protected override void LoadViewState(object savedState)
        {
            Pair states = (Pair)savedState;
            base.LoadViewState(states.First);
            if (states.Second != null)
                ((IStateManager)this.Tabs).LoadViewState(states.Second);
        }
        protected override object SaveViewState()
        {
            Pair pair = new Pair();
            pair.First = base.SaveViewState();
            if (this._tabs != null)
                pair.Second = ((IStateManager)this._tabs).SaveViewState();
            return pair;
        }
        protected override void TrackViewState()
        {
            base.TrackViewState();
            if (this._tabs != null)
                ((IStateManager)this._tabs).TrackViewState();
        }
    }
