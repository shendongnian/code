    public void UpdateTestBox(string newText)
    {
        BeginInvoke((MethodInvoker) delegate {
            tb_output.Text = newText;
        });        
    }
