		#region Background Work of My Request
        private void ProcessMyRequest()
        {            
            if (!bkgWorkerPicking.IsBusy)
            {
                lblMessageToUser.Text = "Processing Request...";
                btnProcessRequest.Enabled = false;
                bkgWorkerMyRequest.RunWorkerAsync();
            }
        }
        private void bkgWorkerMyRequest_DoWork(object sender, DoWorkEventArgs e)
        {
			// let's process what we need in a diferrent thread than the UI thread
            string r = GetStuffDone();
            e.Result = r;
        }
        private void bkgWorkerMyRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string myResult = (String)e.Result;    
			lblMessageToUser.Text = myResult;
            btnProcessRequest.Enabled = true;
        }
        #endregion
		
		private function string GetStuffDone() 
		{
			NetBasisServicesSoapClient client = new NetBasisServicesSoapClient();
            TransactionDetails[] transactions = new TransactionDetails[dataGridView1.Rows.Count - 1];
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                transactions[i] = new TransactionDetails();
                transactions[i].TransactionDate = (string)dataGridView1.Rows[i].Cells[2].Value;
                transactions[i].TransactionType = (string)dataGridView1.Rows[i].Cells[3].Value;
                transactions[i].Shares = (string)dataGridView1.Rows[i].Cells[4].Value;
                transactions[i].Pershare = (string)dataGridView1.Rows[i].Cells[5].Value;
                transactions[i].TotalAmount = (string)dataGridView1.Rows[i].Cells[6].Value;
            }
            CostbasisResult result = client.Costbasis(dataGridView1.Rows[0].Cells[0].Value.ToString(), dataGridView1.Rows[0].Cells[1].Value.ToString(), transactions, false, "", "", "FIFO", true);
            return ConvertStringArrayToString(result.Details);
		}
