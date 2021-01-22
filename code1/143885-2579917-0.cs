    public void DoSomethingToUI(string someParams)
    {
        if(UIControl.InvokeRequired)
        {
            UIControl.BeginInvoke(()=>DoSomethingToUI(someParams));
            return;
        }
        //Do something to the UI Control
    }
