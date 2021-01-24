    public static LogForm MyForm;
    public static void AddLogLine(string inText) // is called from multiple threads
    {
        <namespace>.StaticReference.BeginInvoke((MethodInvoker)delegate
        {
          if (MyForm == null) 
             MyForm = new LogForm();
    
          Do whatever you want with MyForm within this block.
        });
    }
