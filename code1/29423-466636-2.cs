    Timer timer = new Timer();
    timer.Elapsed +=new ElapsedEventHandler(timer_Elapsed);
    static void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
       // The message to process.
       Message message = GetQueueMessage(queue);
    
        // Continue to process while there is a message.
       do while (message != null)
       {
       // Process the message.
    
       // Get the next message.
       message = GetQueueMessage(queue);
       }
    }
