    public delegate void MessageArrivedHandler(MessageBase msg);
    public class MyClass
    {
         public event MessageArrivedHandler MessageArrivedClientHandler;   
    
         public void CallEachDelegate(MessageBase msg)
         {
              if (MessageArrivedClientHandler == null)
                  return;
              Delegate[] clientList = MessageArrivedClientHandler.GetInvocationList();
              foreach (Delegate d in clientList)
              {
                  if (d is MessageArrivedHandler)
                      (d as MessageArrivedHandler)(msg);
              }
         }
    }
