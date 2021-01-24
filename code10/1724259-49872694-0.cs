    private void MyCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        //Don't do this:
        //ThreeSecondMethod();
    
        //Instead, do this:
        Task.Run(() => ThreeSecondMethod());
    }
    
    private void ThreeSecondMethod()
    {
        DateTime deadline = DateTime.Now.AddSeconds(3);
    
        while(DateTime.Now < deadline)
        {
            /* Do nothing */
        }
    
        MessageBox.Show("Done!");
    }
