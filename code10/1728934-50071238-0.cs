        [FunctionName("ServiceBusFunc")]
        public static void Run([ServiceBusTrigger("myqueue", AccessRights.Manage, Connection = "ServiceBus")]BrokeredMessage myQueueItem, TraceWriter log)
        {
            var message = new MyBrokeredMessage(myQueueItem);
            BusinessLogic(message, log);
        }
        public static void BusinessLogic(MyBrokeredMessage myMessage, TraceWriter log)
        {
            var stream = myMessage.GetBody<Stream>();
            var reader = new StreamReader(stream);
            log.Info($"C# ServiceBus queue trigger function processed message: '{reader.ReadToEnd() }'");
        }
        public class MyBrokeredMessage
        {
            private BrokeredMessage _msg;
            public MyBrokeredMessage(BrokeredMessage msg) => _msg = msg;
            public T GetBody<T>()
            {
                return _msg.GetBody<T>();
            }
        }
