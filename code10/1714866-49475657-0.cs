    public void kumme(object sender, KummeClickEventArgs e)
        {
            //here is your logic like:
            //int test = e.MyProperty;
            uCmehanism1.BringToFront();
            int Between = 1;
        }
        public event EventHandler<KummeClickEventArgs> KummeClick; /*Sends info to mechanism*/
        private void KummeNupp(object sender, EventArgs e)
        {
            if(What == 1) /*The name'what' does not exist in current context error*/
            if (this.KummeClick != null)
            {
                var eventArgs = new KummeClickEventArgs
                {
                    MyProperty = 3
                };
                this.KummeClick(this, eventArgs);
            }
        }
