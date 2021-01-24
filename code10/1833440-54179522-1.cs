    public class MyHub : Hub
    {
          public Task SendMessage(Message message)
          {
             JsonConvert.SerializeObject<Message>(message);
           }
    }
