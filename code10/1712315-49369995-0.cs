    //keep your queue object in the service scope
    //you might need more 
    MessageQueue msMq = null;
    protected override void OnStart(string[] args)
    {   
        JobModel j = new JobModel();
        msMq = new MessageQueue(queueRequestName);
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
    //close when you stop
    protected override OnStop() //signature might be differnt
    {
        msMq.Close();
    }
