    public class NonSelectingTextBox : TextBox
    {
        // Base class has a selectionSet property, but its private.
        // We need to shadow with our own variable. If true, this means
        // "don't mess with the selection, the user did it."
        private bool selectionSet;
        protected override void OnGotFocus(EventArgs e)
        {
            bool needToDeselect = false;
            // We don't want to avoid calling the base implementation
            // completely. We mirror the logic that we are trying to avoid;
            // if the base implementation will select all of the text, we
            // set a boolean.
            if (!this.selectionSet)
            {
                this.selectionSet = true;
                if ((this.SelectionLength == 0) && 
                    (Control.MouseButtons == MouseButtons.None))
                {
                    needToDeselect = true;
                }
            }
            // Call the base implementation
            base.OnGotFocus(e);
            // Did we notice that the text was selected automatically? Let's
            // de-select it and put the caret at the end.
            if (needToDeselect)
            {
                this.SelectionStart = this.Text.Length;
                this.DeselectAll();
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                // Update our copy of the variable since the
                // base implementation will have flipped its back.
                this.selectionSet = false;
            }
        }
    }
