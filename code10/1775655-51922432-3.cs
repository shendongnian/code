        public ICommand NotifyFocusedReceivedTxt1Command { get; }
        // in constructor
        this.NotifyFocusedReceivedTxt1Command = new ActionCommand(this.FocusedReceivedTxt1);
        // and method
        private void FocusedReceivedTxt1()
        {
            // Your logic
        }
