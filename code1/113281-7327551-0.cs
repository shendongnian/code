      public static bool IsQueueAvailable(string queueName)
       {
            var queue = new MessageQueue(queueName);
            try
            {
                queue.Peek(new TimeSpan(0, 0, 5));
                return true;
            }
            catch (MessageQueueException ex)
            {
                return ex.Message.StartsWith("Timeout");
            }
        }
