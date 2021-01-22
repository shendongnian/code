    private void DoSomethingOnGui(object o)
    {
        if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Safe_DoSomethingOnGui(o);
            });
        }
        else
        {
        	Safe_DoSomethingOnGui(o);
        }
    }
    private void Safe_DoSomethingOnGui(object o)
    {
        // Do whatever you want with the GUI and o
    }
