        public event EventHandler SelectedIndexChanged
        {
            add { this.TargetControl.SelectedIndexChanged += value; }
            remove { this.TargetControl.SelectedIndexChanged -= value; }
        }
