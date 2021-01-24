    Task.Factory.StartNew(() =>
    {
         for (int i = 0; i < 10; i++)
         {
              // Any GUI control which you want to use within thread,
              // you need Invoke using GUI thread. I have declare a method below for this
              //Now use this method as
              ExecuteSecure(() => textBox1.Text = "Customer Id " + i);
              //... other code etc.
              Thread.Sleep(1000);
         }
    });
    
    
    //---
    private void ExecuteSecure(Action action)
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(() => action()));
        }
        else
        {
            action();
        }
    }
