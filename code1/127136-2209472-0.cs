    private void OnFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       if ( IsDataModified() )  // check if the data is unsaved...however you do so
       {
          // display a message asking the user to save changes or abort.
          if(MessageBox.Show("Do you want to save your changes?", 
                             "My Application", 
                             MessageBoxButtons.YesNo) ==  DialogResult.Yes)
          {
              if( !SaveChanges(); )
                  e.Cancel = true; // save did not succeed!
          }
       }
    }
