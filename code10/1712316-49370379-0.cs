    protected override void OnStart(string[] args)
    {
        MessageQueue msMq = null;
        JobModel j = new JobModel();
        msMq = new MessageQueue(queueRequestName);
        msMq.ReceiveCompleted += ReceiveCompletedEventHandler(MyMsMqEventHandler)
        try
        {            
            if (msMq != null)
            {                    
                msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(JobModel) });
                var message = (JobModel)msMq.BeginReceive();        
            }
        }
        catch (MessageQueueException ee)
        {
            Console.Write(ee.ToString());
        }
        catch (Exception eee)
        {
            Console.Write(eee.ToString());
        }
    }
    
    public static void MyMsMqEventHandler(object src, ReceiveCompletedEventHandler handler)
    {
         var msMq = (MessageQueue)src;
         var msg = msMq.EndReceive(handler.AsyncResult);
         Console.WriteLine((string)msMq.Body);
         msMq.BeginReceive();
    }
