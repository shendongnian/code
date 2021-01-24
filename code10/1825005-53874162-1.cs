    public class Queue : IDisposable
    {
        private readonly Thread _messageThread; // thread for processing messages
        private readonly BlockingCollection<Message> _messages; // queue for messages
        private readonly CancellationTokenSource _cancellation; // used to abort the processing when we're done
        // initializes everything and starts a processing thread
        public Queue()
        {
            _messages = new BlockingCollection<Message>();
            _cancellation = new CancellationTokenSource();
            _messageThread = new Thread(ProcessMessages);
            _messageThread.Start();
        }
        // processing thread function
        private void ProcessMessages()
        {
            try
            {
                while (!_cancellation.IsCancellationRequested)
                {
                    // Take() blocks until either:
                    // 1) a message is available, in which case it returns it, or
                    // 2) the cancellation token is cancelled, in which case it throws an OperationCanceledException
                    var message = _messages.Take(_cancellation.Token); 
                    // process the message here
                }
            }
            catch (OperationCanceledException)
            {
                // Take() was cancelled, let the thread exit
            }
        }
        // pushes a message
        public void QueueMessage(Message message)
        {
            _messages.Add(message);
        }
        // stops processing and clean up resources
        public void Dispose()
        {
            _cancellation.Cancel(); // let Take() abort by throwing
            _messageThread.Join(); // wait for thread to exit
            _cancellation.Dispose(); // release the cancellation source
            _messages.Dispose(); // release the queue
        }
    }
