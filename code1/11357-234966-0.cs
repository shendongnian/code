    private void initEMS()
    {
    	Tibems.SetExceptionOnFTSwitch(true);
    	_ConnectionFactory = new TIBCO.EMS.TopicConnectionFactory(<server>);
    	_ConnectionFactory.SetReconnAttemptCount(30);		// 30retries
    	_ConnectionFactory.SetReconnAttemptDelay(120000);	// 2minutes
    	_ConnectionFactory.SetReconnAttemptTimeout(2000);	// 2seconds
    _Connection = _ConnectionFactory.CreateTopicConnectionM(<username>, <password>);
    	_Connection.ExceptionHandler += new EMSExceptionHandler(_Connection_ExceptionHandler);
    }
    private void _Connection_ExceptionHandler(object sender, EMSExceptionEventArgs args)
    {
    	EMSException e = args.Exception;
    	// args.Exception = "Connection has been terminated" -- single server failure
    	// args.Exception = "Connection has performed fault-tolerant switch to <server url>" -- fault-tolerant multi-server
    	MessageBox.Show(e.ToString());
    }
