    private void DoSomethingOnGui()
    {
        if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Safe_DoSomethingOnGui();
            });
        }
        else
        {
        	Safe_DoSomethingOnGui();
        }
    }
    private void Safe_DoSomethingOnGui()
    {
        // Do whatever you want with the GUI
    }
