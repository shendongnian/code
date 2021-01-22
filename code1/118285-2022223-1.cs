        private void Form1_Load(object sender, EventArgs e)
        {
            Action<bool> act = (bool myBool) =>
                {
                    Thread.Sleep(5000);
                };
            act.BeginInvoke(true, new AsyncCallback((IAsyncResult result) =>
            {
                Callback c = result.AsyncState as Callback;
                c.Control.Invoke(c.Method);
            }), new Callback()
            {
                Control = this,
                Method = () => { ShowMessageBox(); }
            });            
        }
