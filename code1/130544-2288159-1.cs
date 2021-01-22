    using System.Runtime.Remoting.Messaging;
    ...
    static void back_DoWork() 
    {
        AddRoot root = FindRoot;
        root.BeginInvoke(12.0, new AsyncCallback(callback), root);
    }
    
    static void callback(IAsyncResult result) 
    {
        AddRoot dlg = (AddRoot)(((AsyncResult)result).AsyncDelegate);
        
        try 
        {
            dlg.EndInvoke(result);
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
