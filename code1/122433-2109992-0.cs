    private void Form_Shown(object sender, System.EventArgs e)
    {
         // Focus on the first tab page
         tabControl1.TabPages[0].Focus(); 
         tabControl1.TabPages[0].CausesValidation = true; 
    }
    
    private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e) 
    { 
         // Whenever the current tab page changes
         tabControl1.TabPages[tabControl1.SelectedIndex].Focus(); 
         tabControl1.TabPages[tabControl1.SelectedIndex].CausesValidation = true; 
    }
    
    
    private void tabPage1_Validating(object sender, System.ComponentModel.CancelEventArgs e) 
    { 
         // Validate the tab controls as required,  if there are any problems use:
         e.Cancel = true; 
    }
