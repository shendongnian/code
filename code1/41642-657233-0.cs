    class EmailSender
    {
        Queue<Message> messages;
        List<Thread> threads;
        public Send(IEnumerable<Message> messages, int threads)
        {
            this.messages = new Queue<Message>(messages);
            this.threads = new List<Thread>();
            while(threads-- > 0)
                threads.Add(new Thread(SendMessages));
            
            threads.ForEach(t => t.Start());
            while(threads.Any(t => t.IsAlive))
                Thread.Sleep(50);
        }
        private SendMessages()
        {
            while(true)
            {
                Message m;
                lock(messages)
                {
                    try
                    {
                        m = messages.Dequeue();
                    }
                    catch(InvalidOperationException)
                    {
                        // No more messages
                        return;
                    }
                }
                // Send message in some way. Not in an async way, 
                // since we are already kind of async.
                Thread.Sleep(); // Perhaps take a quick rest
            }
        }
    }
