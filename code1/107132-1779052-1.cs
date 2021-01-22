        private void RefreshButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Working...";
            RefreshButton.Enabled = false;
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                // do work here
                // e.g.
                var datasource = GetData();
                this.Invoke((Action)delegate()
                {
                    // gridview should also be accessed in UI thread
                    // e.g.
                    MyGridView.DataSource = datasource;
                    
                    MessageLabel.Text = "Done.";
                    RefreshButton.Enabled = true;
                });
            });
        }
