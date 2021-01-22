    // Consumer of DerivedMessageOne and DerivedMessageTwo 
    // (some process or timer, etc that wants to receive messages)
    public class DerivedMessageHandlerOne : 
       IMessageHandler<DerivedMessageOne>, 
       IMessageHandler<DerivedMessageTwo>
       // Just add handlers here to process incoming messages
    {
       private AutoResetEvent mWaitForMessage = new AutoResetEvent(false);
      
       public DerivedMessageHandlerOne() { }
       #region IMessageHandler<MessaegType> Members
       // ************ handle both messages *************** //
       public void ProcessMessage(DerivedMessageOne message)
       {
         // Received Message one, do something with it
       }
       public void ProcessMessage(DerivedMessageTwo message)
       {
          // Received Message two, do something with it   
       }
       #endregion
    }
