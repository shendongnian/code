    private delegate void DisplayDialogCallback();
    
    public void DisplayDialog()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new DisplayDialogCallback(DisplayDialog));
        }
        else
        {
            if (this.Handle != (IntPtr)0) // you can also use: this.IsHandleCreated
            {
                this.ShowDialog();
    
                if (this.CanFocus)
                {
                    this.Focus();
                }
            }
            else
            {
                // Handle the error
            }
        }
    }
