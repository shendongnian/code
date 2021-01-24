    public delegate void CallBackDelegate(string status);  
    public CallBackDelegate HollaBack
    {
       get; set;
    }
            
    private void DoCallBack(string inMsg)
    {
       // Make sure the callback method was set
       if (HollaBack != null)
       {
          // send text to the callback method
          HollaBack(inMsg);
       }
    }
    
    // Invoke the callback anywhere within DLL B
    DoCallBack("show this in the status window");
