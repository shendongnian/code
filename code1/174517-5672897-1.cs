        override protected void OnDeactivated(EventArgs e)
        {
            this._lostFocusTime = DateTime.Now;
 	        base.OnDeactivated(e);
        }
        protected override void OnActivated(EventArgs e)
        {
            this._lostFocusTime = null;
            base.OnActivated(e);
        }
