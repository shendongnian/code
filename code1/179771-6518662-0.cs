        /// <summary>
        /// Attach an event handler for the text changed event
        /// </summary>
        private void attachTextChangedEventHandler()
        {            
        var input = (from evt in Observable.FromEventPattern<EventArgs>(textBox1,"TextChanged")
        .select ((TextBox)evt.Sender).Text)
        .DistinctUntilChanged()
        .Throttle(TimeSpan.FromSeconds(1));
        input.ObserveOn(treeView1).Subscribe(filterHandler, errorMsg);
        }
        private void filterHandler(string filterText)
        {
            Loadtreeview(filterText);
        }
