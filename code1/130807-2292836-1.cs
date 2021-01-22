        private void Update(string info)
        {
         ObserverDelegate callBack =  new ObserverDelegate((x) =>
                {
                    this.logBox.Text += Environment.NewLine + info;
                });             
            
            if (this.InvokeRequired)
                this.Invoke(callBack, info);
            else
              callBack(info);
        }
