    class CleverTextBox : TextBox
    {
        private string previousText = string.Empty;
    
        public CleverTextBox() : base()
        {
            // Maybe set the value here, not sure if this is necessary..?
            this.previousText = base.Text;
        }
    
        public override OnTextChanged(EventArgs e)
        {
            // Only raise the event if the text actually changed
            if (this.previousText != base.Text)
            {                
                this.previousText = this.Text;
                base.OnTextChanged(e);
            }
        }
    }
