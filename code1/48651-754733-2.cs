    private void InitQueue()
    {
        this.translationQueue = new EventQueue<QueueRequest>();
        this.translationQueue.OnQueueMadeEmpty += new EventQueue<QueueRequest>.OnQueueMadeEmptyDelegate(translationQueue_OnQueueMadeEmpty);
        this.translationQueue.OnQueueMadeNonEmpty += new EventQueue<QueueRequest>.OnQueueMadeNonEmptyDelegate(translationQueue_OnQueueMadeNonEmpty);
    }
    
    void translationQueue_OnQueueMadeNonEmpty()
    {
        while (translationQueue.Count() > 0)
        {
            lock (queueLock)
            {
                QueueRequest request = translationQueue.Dequeue();
    #if DEBUG
                System.Diagnostics.Debug.WriteLine("Item taken from queue...");
    #endif
                // hard work
                ....
                ....
                ....
            }
        }
    }
    
    void translationQueue_OnQueueMadeEmpty()
    {
        // empty queue
        // don't actually need to do anything here?
    }
    
    private void onMessageReceived(....)
    {
      ....
      ....
      ....
      // QUEUE REQUEST
      lock (queueLock)
      {
        QueueRequest queueRequest = new QueueRequest
                                        {
                                            Request = request,
                                            Sender = sender,
                                            Recipient = tcpClientService
                                        };
        translationQueue.Enqueue(queueRequest);
    #if DEBUG
        System.Diagnostics.Debug.WriteLine("Item added to queue...");
    #endif
      }
    }
