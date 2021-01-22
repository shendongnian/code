        #region MouseEnter & Leave
        private bool _childControlsAttached = false;
        /// <summary>
        /// Attach enter & leave events to child controls (recursive), this is needed for the ContainerEnter & 
        /// ContainerLeave methods.
        /// </summary>
        private void AttachMouseOnChildren() {
            if (_childControlsAttached) {
                return;
            }
            this.AttachMouseOnChildren(this.Controls);
            _childControlsAttached = true;
        }
        /// <summary>
        /// Attach the enter & leave events on a specific controls collection. The attachment
        /// is recursive.
        /// </summary>
        /// <param name="controls">The collection of child controls</param>
        private void AttachMouseOnChildren(System.Collections.IEnumerable controls) {
            foreach (Control item in controls) {
                item.MouseLeave += new EventHandler(item_MouseLeave);
                item.MouseEnter += new EventHandler(item_MouseEnter);
                this.AttachMouseOnChildren(item.Controls);
            }
        }
        /// <summary>
        /// Will be called by a MouseEnter event, with any of the controls within this
        /// </summary>
        void item_MouseEnter(object sender, EventArgs e) {
            this.OnMouseEnter(e);
        }
        /// <summary>
        /// Will be called by a MouseLeave event, with any of the controls within this
        /// </summary>
        void item_MouseLeave(object sender, EventArgs e) {
            this.OnMouseLeave(e);
        }
        /// <summary>
        /// Flag if the mouse is "entered" in this control, or any of its children
        /// </summary>
        private bool _containsMouse = false;
        /// <summary>
        /// Is called when the mouse entered the Form, or any of its children without entering
        /// the form itself first.
        /// </summary>
        protected void OnContainerEnter(EventArgs e) {
            // No longer transparent
            this.Opacity = 1;
            this.tmrAppear.Enabled = false;
            // Focus this control, this will let the toolbar act on first click
            this.Focus();
        }
        /// <summary>
        /// Is called when the mouse leaves the form. When the mouse leaves the form via one of
        /// its children, this will also call OnContainerLeave
        /// </summary>
        /// <param name="e"></param>
        protected void OnContainerLeave(EventArgs e) {
            this.Opacity = DEFAULT_OPACITY;
        }
        /// <summary>
        /// <para>Is called when a MouseLeave occurs on this form, or any of its children</para>
        /// <para>Calculates if OnContainerLeave should be called</para>
        /// </summary>
        protected override void OnMouseLeave(EventArgs e) {
            Point clientMouse = PointToClient(Control.MousePosition);
            if (!ClientRectangle.Contains(clientMouse)) {
                this._containsMouse = false;
                OnContainerLeave(e);
            }
        }
        /// <summary>
        /// <para>Is called when a MouseEnter occurs on this form, or any of its children</para>
        /// <para>Calculates if OnContainerEnter should be called</para>
        /// </summary>
        protected override void OnMouseEnter(EventArgs e) {
            if (!this._containsMouse) {
                _containsMouse = true;
                OnContainerEnter(e);
            }
        }
        #endregion
