    public class Handler : IHandleMessages<Message>
    {
      public Task Handle(Message message, IMessageHandlerContext context)
      {
        var responseMessage = new ResponseMessage
        {
            Result = "TheResult"
        };
        return context.Reply(responseMessage);
      }
    }
