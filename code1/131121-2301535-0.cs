    void conn_PageDeleted(object sender, string name)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateLabelHandler(UpdateMe), new object[] {sender, name}); //<-- the update goes here
            }
            else
            {
                lblDeleteStatus.Text = name;                
            }
        }
