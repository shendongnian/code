        public ICommand NotifyFocusedReceivedCommand { get; }
        // in constructor
        this.NotifyFocusedReceivedCommand = new ActionCommand(this.FocusedReceived);
        // and method
        private void FocusedReceived(object control)
        {
            var txt = (TextBox)control;
            bool isFocused = txt.IsFocused;
            string name = txt.Name;
        }
