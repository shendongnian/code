    private void FormMain_Load (object sender, EventArgs e)
    {
        if (MyFunc())
        {
            CancelLoading();
        }
    }
    private delegate void InvokeDelegate();
    
    private void CancelLoading()
    {    // will cancel loading this form
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.BeginInvoke(new InvokeDelegate(CloseThisForm));
    }
    
    private void CloseThisForm()
    {
        this.Close();
    }
