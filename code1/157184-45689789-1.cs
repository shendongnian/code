    var errorProvider1 == new ErrorProvider();
    protected void textBox1_Validating (object sender,  System.ComponentModel.CancelEventArgs e)  
    {  
       try  
       {  
          int x = Int32.Parse(textBox1.Text);
          // Clear the error.  
          errorProvider1.SetError(textBox1, "");  
       }  
       catch (Exception ex)  
       {  
          errorProvider1.SetError(textBox1, "Not an integer value."); 
          // additionally, if you wantto prevent user leaving textbox 
          // until he satisfies condition. uncomment below.
          // e.handled = true; 
       }  
    }  
