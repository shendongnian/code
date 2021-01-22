    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Could not find the folder, so the D:  Drive will be opened instead.", 
                "", System.Windows.Forms.MessageBoxButtons.OKCancel);
    
            if (result == System.Windows.Forms.DialogResult.OK)
                MessageBox.Show("OK");
            else
                MessageBox.Show("Do nothing.");
