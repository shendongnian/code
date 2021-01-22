        private void RefreshButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Working...";
            RefreshButton.Enabled = false;
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                // do work here 
                // e.g. 
                object datasource = GetData();
                this.Invoke((Action<object>)delegate(object obj)
                {
                    // gridview should also be accessed in UI thread 
                    // e.g. 
                    MyGridView.DataSource = obj;
                    MessageLabel.Text = "Done.";
                    RefreshButton.Enabled = true;
                }, datasource);
            });
        }
