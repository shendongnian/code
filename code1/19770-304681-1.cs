    void business_Deleted(object sender, EventArgs e)
    {
        if ( false == object.ReferenceEquals( sender, this.currentlyDeletingBusiness ) ) {
            MessageBox.Show("Item has been deleted in another editor window.",
                "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        Close();
    }
    Business currentlyDeletingBusiness;
    private void deleteButton_Activate(object sender, EventArgs e)
    {
        Business c = (Business)businessBindingSource.DataSource;
        try {
            this.currentlyDeletingBusiness = c;
            c.Delete();
        }
        finally {
            this.currentlyDeletingBusiness = null;
        }
    }
