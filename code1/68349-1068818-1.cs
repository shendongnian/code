     private void bCreateInvoices_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(CreateInvoices);
            worker.RunWorkerAsync(this);
        }
     // Here is the long running function that needs to update the progress bar
     public void CreateInvoices(object sernder, DoWorkEventArgs e)
        {
            int totalChecked = CountCheckedServiceOrders();
            int totalCompleted = 0;
            foreach (...data to process...) {
                totalCompleted++;
                if (InvokeRequired) {
                   Invoke(new Change(OnChange), "status text", 
                            totalCompleted, totalChecked);                
                }
            }
        }
        // this code updates the status while a background thread works
        private delegate void Change(string status, int complete, int total);
        private void OnChange(string status, int complete, int total)
        {
            if (status == null) {
                progressBar.Visible = false;
                lStatus.Text = "Task complete";
                progressBar.Value = 0;
            } else {
                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = total;
                progressBar.Value = complete;
                lStatus.Text = status;
            }
            
        }
