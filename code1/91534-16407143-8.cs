    public class MessageBase<MessageType> : IMessage
       where MessageType : class, IMessage
    {
       public void Dispatch(IHandler handler)
       {
          MessageType msg_as_msg_type = this as MessageType;
          if (msg_as_msg_type != null)
          {
             DynamicDispatch(handler, msg_as_msg_type);
          }
       }
       protected void DynamicDispatch(IHandler handler, MessageType self)
       {
          IMessageHandler<MessageType> handlerTarget = 
             handler as IMessageHandler<MessageType>;
          if (handlerTarget != null)
          {
             handlerTarget.ProcessMessage(self);
          }
       }
    }
