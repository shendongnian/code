    private void Home_Load(object sender, EventArgs e)
        {
            if (GetPurchase())
            {
                forApprovalToolStripMenuItem.Image = Properties.Resources.sign_check_icon;
            }
            else
            {
                forApprovalToolStripMenuItem.Checked = false;
            }
            itemRequestsToolStripMenuItem.Enabled = true;
            forApprovalToolStripMenuItem.Enabled = false;
        }
        bool GetPurchase()
        {
            bool withPending;
            using (SqlConnection con = new SqlConnection(Helper.GetConnection()))
            {
                con.Open();
                string query = @"SELECT POID FROM purchaseorder_table WHERE status='Pending'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    return withPending = cmd.ExecuteScalar() == null ? false : true;
                }
            }
        }
