    private async void btnCopyAllInvoices_Click(object sender, EventArgs e) {
        //sets up a list to store the incoming invoice numbers from the DB
        List<string> InvoiceNums = new List<string>();
        mySqlInterface.Connect();
    
        InvoiceNums = mySqlInterface.GetNewInvoices();
    
        //prep the visuals
        lblStatus.Text = "";
        InvoicePanel.Visible = true;
        progressBarInvoice.Value = 0;
        progressBarInvoice.Maximum = InvoiceNums.Count;
    
        //for each invoice collected let's copy it
        foreach(string inv in InvoiceNums) {
            if (OrderDAL.CheckOrderExist(inv)) {
                // the order already exist
                Order myorder = OrderDAL.GetOrder(inv);
    
                await CopyImages(myorder, true);
    
                OrderDAL.UpdateFulfillment(string.Format("Images Copied"), inv);    
            }
        }
    
        //let the user know how we did
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        string strError = string.Format("{0} Invoices copied.", InvoiceNums.Count);
        MessageBox.Show(this, strError, "Copy New Invoices", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
    
        InvoicePanel.Visible = false;
    }
