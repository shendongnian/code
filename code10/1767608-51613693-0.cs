    public void MyCallBack(string status)
    {
       // Add callback text to the status window
       StatTxt.AppendText(status);
    }
    // Set the callback method in DLL B
    B.HollaBack = MyCallBack;
