    delegate void ProcessImagesDelegate(string did, string sourceFolder, string destFolder, string strNumImages);
    private void ProcessImages(string DID, string SourceFolder, string DestFolder, string strNumImages)
    {
        // do work
        // update textbox in form
        if (this.textBox1.InvokeRequired)
        {
            this.textBox1.Invoke(new MethodInvoker(delegate() { this.textBox1.Text = "delegate update"; }));
        }
        else
        {
            this.textBox1.Text = "regular update";
        }
        // do some more work
    }
    public void MyMethod()
    {
        new ProcessImagesDelegate(ProcessImages).BeginInvoke(tbDID.Text, tbSource.Text, tbDest.Text, comboBoxNumberImages.SelectedItem.ToString(), null, null);
    }
