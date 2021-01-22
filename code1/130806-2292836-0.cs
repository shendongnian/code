        private void Update(string info)
        {
            
            if (this.InvokeRequired)
            {
                this.Invoke(new ObserverDelegate((x) =>
                {
                    this.logBox.Text += Environment.NewLine + info;
                }), info);
            }
        }
