    public static void SendMsmqMessage(string queueName, string data)
    {
        //Define the queue path based on the input parameter.
        string QueuePath = String.Format(".\\private$\\{0}", queueName);
        try
        {
            if (!MessageQueue.Exists(QueuePath))
                MessageQueue.Create(QueuePath);
            //Open the queue with the Send access mode
            MessageQueue MSMQueue = new MessageQueue(QueuePath, QueueAccessMode.Send);
            //Define the queue message formatting and create message
            BinaryMessageFormatter MessageFormatter = new BinaryMessageFormatter();
            Message MSMQMessage = new Message(data, MessageFormatter);
            MSMQueue.Send(MSMQMessage);
        }
        catch (Exception x)
        {
            // async logging: gotta return from the trigger ASAP
            System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(LogException), x);
        }
    }
