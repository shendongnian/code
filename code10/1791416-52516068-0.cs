        private void frmMain_Load(object sender, EventArgs e)
        {
    
            pnlItems.Visible = true;
            pnlCustomer.Visible = false;
            pnlPOS.Visible = false;
        }
        
        private void btnItems_Click(object sender, EventArgs e)
        {
    if(pnlItems.Visible != true){
            pnlItems.Visible = true;
            pnlCustomer.Visible = false;
            pnlPOS.Visible = false;
    }
        }
        
        private void btnCustomers_Click(object sender, EventArgs e)
        {
    if(pnlCustomer.Visible != true){
            pnlCustomer.Visible = true;
            pnlItems.Visible = false;
            pnlPOS.Visible = false;
        }
    }
        
        private void btnPOS_Click(object sender, EventArgs e)
        {
    if(pnlPOS.Visible != true){
            pnlPOS.Visible = true;
            pnlCustomer.Visible = false;
            pnlItems.Visible = false;
        }
    }
