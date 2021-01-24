    public void Show()
    {
	    var message = new MQMessage();
	    try
	    {
		    var getMessageOptions = new MQGetMessageOptions();
		    getMessageOptions.Options = MQC.MQGMO_BROWSE_FIRST;
		    _queue.Get(message, getMessageOptions);
		    var msg = message.ReadString(message.MessageLength);
		    Console.WriteLine("Preview of message: " + msg);
	    }
	    catch (MQException exp)
	    {
		    Console.WriteLine(exp.Message);
		    throw;
	    }
    }
