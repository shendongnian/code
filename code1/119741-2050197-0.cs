        private UserControl _uc = null;
    /// <summary>
        /// Creates all controls.
        /// </summary>
        /// <remarks>All the controls must be created in this method for the event handler</remarks>
        protected override void CreateChildControls()
        {
            _uc = new UserControl ();
            this.Controls.Add(_uc);
            base.CreateChildControls();
        }
