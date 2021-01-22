        private void CallMyCodeNow()
        {
            label1.Text = "reactivated!";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var o = Observable.FromEventPattern<EventHandler, EventArgs>(
                handler => button1.Click += handler
                , handler => button1.Click -= handler
                )
                .Delay(TimeSpan.FromSeconds(5))
                .ObserveOn(SynchronizationContext.Current)  // ensure event fires on UI thread
                .Subscribe(
                    ev => CallMyCodeNow()
                    , ex => MessageBox.Show(ex.Message)
                );
        }
 
