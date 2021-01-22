    c.Delete( this ); //this = window
    // ...
    void business_Deleted(object sender, EventArgs e) {
        bool isDeletedFromMe = false;
        if ( e is DeletedEventArgs ) { isDeletedFromMe = object.ReferenceEquals( this, e.Author ); }
        if ( false == isDeletedFromMe ) {
            MessageBox.Show("Item has been deleted in another editor window.",
                "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Close();
        }
    }
