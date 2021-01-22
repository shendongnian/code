    public class Tab : IStateManager
    {
        private StateBag _viewState;
        private bool _isTrackingViewState;
        public string Label
        {
            get { return (string)ViewState["Label"] ?? string.Empty; }
            set { ViewState["Label"] = value; }
        }
        [Browsable(false)]
        protected virtual StateBag ViewState
        {
            get
            {
                if (this._viewState == null)
                {
                    this._viewState = new StateBag(true);
                    if (this._isTrackingViewState)
                        ((IStateManager)this._viewState).TrackViewState();
                }
                return this._viewState;
            }
        }
        bool IStateManager.IsTrackingViewState
        {
            get { return this._isTrackingViewState; }
        }
        void IStateManager.LoadViewState(object state)
        {
            if (state != null)
                ((IStateManager)this.ViewState).LoadViewState(state);
        }
        object IStateManager.SaveViewState()
        {
            if (this._viewState != null)
                return ((IStateManager)this._viewState).SaveViewState();
            return null;
        }
        void IStateManager.TrackViewState()
        {
            this._isTrackingViewState = true;
            if (this._viewState != null)
                ((IStateManager)this._viewState).TrackViewState();
        }
    }
