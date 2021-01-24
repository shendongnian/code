        public class MyHub : Hub
        {
              public Task SendMessage(Message message)
              {
                 var messageJsonString = JsonConvert.SerializeObject<Message>(message);
                 // some logic
               }
        }
