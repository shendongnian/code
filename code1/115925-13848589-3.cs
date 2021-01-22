    private void frmSalesOrderForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        switch (e.CloseReason)
        {
            case CloseReason.UserClosing:
                switch(this.DialogResult == DialogResult.OK)
                {
                    case DialogResult == DialogResult.OK:
                        // User has clicked button.
                        break;
                    case DialogResult == DialogResult.Cancel:
                        // User has clicked X on form.
                        break;
                }
                break;
         }
    }
