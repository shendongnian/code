    private void MyForm_Load (object sender, EventArgs e)
    {
        // do some initializations
        
        if (!ContinueLoadingForm())
        {
             this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
             this.Close();
             return;
        }
        // continue loading the form
    }
