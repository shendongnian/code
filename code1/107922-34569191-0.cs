    public object Receive(string path, int millisecondsTimeout)
    {
	    var mq = new System.Messaging.MessageQueue(path);
	    var asyncResult = mq.BeginReceive();
	    var handles = new System.Threading.WaitHandle[] { asyncResult.AsyncWaitHandle };
    	var index = System.Threading.WaitHandle.WaitAny(handles, millisecondsTimeout);
    	if (index == 258) // Timeout
    	{
    		mq.Close();
    		return null;
    	}
    	var result = mq.EndReceive(asyncResult);
    	return result;
    }
