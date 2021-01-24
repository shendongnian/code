    public class Processor
    {
        private readonly IMessagingSystem _messagingSystem;
        private readonly ActionBlock<Message> _handler;
        private bool _pollForMessages;
        public Processor(IMessagingSystem messagingSystem)
        {
            _messagingSystem = messagingSystem;
            _handler = new ActionBlock<Message>(msg => Process(msg), new ExecutionDataflowBlockOptions()
            {
                MaxDegreeOfParallelism = 5 //or any configured value
            });
        }
        public async Task Start()
        {
            _pollForMessages = true;
            while (_pollForMessages)
            {
                var msg = await _messagingSystem.ReceiveMessageAsync();
                await _handler.SendAsync(msg);
            }
        }
        public void Stop()
        {
            _pollForMessages = false;
        }
        private void Process(Message message)
        {
            //handle message
        }
    }
