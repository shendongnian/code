    partial class MyControl : System.Web.UI.UserControl, IStateManager
    {
        [Serializable()]
        protected struct MyControlState
        {
            public bool someValue;
            public string name;
        }
        protected MyControlState state;
        public bool someValue {
            get { return state.someValue; }
            set { state.someValue = value; }
        }
        public bool IsTrackingViewState {
            get { return true; }
        }
        protected override void LoadViewState(object state)
        {
            state = getDefaultState();
            if ((state != null) && state is MyControlState) {
                this.state = state;
            }
        }
        
        protected override object SaveViewState()
        {
            return state;
        }
            
        protected override void TrackViewState()
        {
            base.TrackViewState();
        }
    }
