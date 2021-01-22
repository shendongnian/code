        public void DelegateMethod(string header)
        {
            tabMain.Dispatcher.BeginInvoke(
                    new Action(() => {
                        this.AddToParent(header);
                    }), null);
        }
