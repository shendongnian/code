    // Consumer of DerivedMessageOne and DerivedMessageTwo 
    // (some task or process that wants to receive messages)
    public class DerivedMessageHandlerOne : 
       IMessageHandler<DerivedMessageOne>, 
       IMessageHandler<DerivedMessageTwo>
       // Just add handlers here to process incoming messages
    {     
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
