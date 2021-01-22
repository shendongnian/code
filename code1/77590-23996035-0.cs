    private static void MyReceiveCompleted(Object source,
            ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            try
            {
                Message[] mm = mq.GetAllMessages();
                foreach (Message m in mm)
                {
                // do whatever you want
                }
            }
            catch (MessageQueueException me)
            {
                Console.WriteLine(me.Message);
            }
            finally
            {
                
            }
            
            return;
        }
