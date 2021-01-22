    private void Form_Shown(object sender, System.EventArgs e)
    {
         // Focus on the first tab page
         tabControl1.TabPages[0].Focus(); 
         tabControl1.TabPages[0].CausesValidation = true; 
         tabControl1.TabPages[0].Validating += new CancelEventHandler(Page1_Validating);
         tabControl1.TabPages[1].Validating += new CancelEventHandler(Page2_Validating);
     }
        void Page1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                e.Cancel = true; 
            }
        }
        void Page2_Validating(object sender, CancelEventArgs e)
        {
            if (checkBox1.Checked   == false)
            {
                e.Cancel = true;
            }
        }
   
    private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e) 
    { 
         // Whenever the current tab page changes
         tabControl1.TabPages[tabControl1.SelectedIndex].Focus(); 
         tabControl1.TabPages[tabControl1.SelectedIndex].CausesValidation = true; 
    }
    
    
