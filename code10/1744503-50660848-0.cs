    void tmr_Tick(object sender, EventArgs e)
    
     {
    
         //after 3 sec stop the timer
    
         tmr.Stop();
    
         //display mainform
    
         Mainform mf = new Mainform();
    
         mf.Show();
    
         //hide this form
    
         this.Hide();
    
     }
    
    Double-click on the FormClosed Event and add this Code:
    private void Mainform_FormClosed(object sender, FormClosedEventArgs e)
    
    {
    
         //exit application when form is closed
    
         Application.Exit();
    
    } 
