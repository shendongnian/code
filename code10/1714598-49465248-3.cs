    public void DoTheThing(TextBox txCmd, TextBox txWait){
        txCmd.BackColor = Color.Salmon;
        ProcessCmd(txCmd.Text);
        System.Threading.Thread.Sleep(txWait.Text)
        txCmd.BackColor = Color.White;
    }
