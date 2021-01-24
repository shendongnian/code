        private void AskToSaveChanges()
        {
            // note: MyMessageBox is a class in UI layer, because it uses UI component 
            // of Windows forms
            if (MyMessageBox.Show(MyMessageBoxActions.Save, ""))
                SaveChanges(); // this is done in Persistence layer
            else
                RejectChanges(); // this is done in Persistence layer
        }
        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            _isFormClosing = true;
    
            if (_isDataModified == false || AskToSaveChanges()) 
               this.Close();
        }
