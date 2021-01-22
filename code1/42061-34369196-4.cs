    Task.Factory.StartNew(()=>
    {
        // THIS IS NOT GUI
        Thread.Sleep(5000);
        // HERE IS INVOKING GUI
        btn_login.Invoke(new Action(()=>DoSomethingOnGUI()));
    });
    
    private void DoSomethingOnGUI()
    {
       // GUI
       MessageBox.Show("message", "title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
