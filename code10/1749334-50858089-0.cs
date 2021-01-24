    public class PrimaryWork
    {
        private readonly BlockingCollection<EmailModel> _enqueuer;
    
        public PrimaryWork(BlockingCollection<EmailModel> enqueuer)
        {
            _enqueuer = enqueuer;
        }
    
        public void DoWork()
        {
            // ... do your work
            EnqueueEmail(new EmailModel { 
              To = $"recipient{i}@foo.com", 
              Message = $"Message {i}" });
        }
    
        // i.e. Queue work for the email sender
        private void EnqueueEmail(EmailModel message)
        {
            _enqueuer.Add(message);
        }
    }
    public class EmailSender
    {
        private readonly BlockingCollection<EmailModel> _mailQueue;
        private readonly TaskCompletionSource<string> _tcsIsCompleted 
            = new TaskCompletionSource<string>();
        public EmailSender(BlockingCollection<EmailModel> mailQueue)
        {
            _mailQueue = mailQueue;
        }
        public void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    while (!_mailQueue.IsCompleted)
                    {
                        var nextMessage = _mailQueue.Take();
                        SendEmail(nextMessage).Wait();
                    }
                    _tcsIsCompleted.SetResult("ok");
                }
                catch (Exception)
                {
                    _tcsIsCompleted.SetResult("fail");
                }
            });
        }
        public async Task Stop()
        {
            _mailQueue.CompleteAdding();
            await _tcsIsCompleted.Task;
        }
        private async Task SendEmail(EmailModel message)
        {
            // IO bound work to the email server goes here ...
        }
    }
