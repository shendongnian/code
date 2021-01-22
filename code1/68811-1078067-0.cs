    frmRb obj = new frmrb();
    private void btnPd_Click(object sender, EventArgs e)
            {
               btnCancel.Enabled = true;
               obj.btnRtn.Enabled = true;
            }
    
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
                obj.Show();
                obj.BringToFront();
                obj.Focus();                
            }
