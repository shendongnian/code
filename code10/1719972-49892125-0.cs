    The connection code:
    System.Collections.Hashtable queueProperties = new System.Collections.Hashtable();
    queueProperties[MQC.HOST_NAME_PROPERTY] = host;
    queueProperties[MQC.PORT_PROPERTY] = port;
    queueProperties[MQC.CHANNEL_PROPERTY] = channel;            
    queueManager = new MQQueueManager(queueManagerName, queueProperties);                
    The write code:
    queue = queueManager.AccessQueue(queueName, MQC.MQOO_INPUT_SHARED + MQC.MQOO_FAIL_IF_QUIESCING + MQC.MQOO_OUTPUT + MQC.MQOO_BROWSE);                
    queueMessage = new MQMessage();
    queueMessage.WriteString(message);
    queueMessage.Persistence = 0;
    queueMessage.Format = MQC.MQFMT_STRING;
    queuePutMessageOptions = new MQPutMessageOptions();
    queue.Put(queueMessage, queuePutMessageOptions);
    queueManager.Disconnect();
    queue.Close(); 
    
    The read code :
    queue = queueManager.AccessQueue(queueName, MQC.MQOO_INQUIRE + MQC.MQOO_BROWSE + MQC.MQOO_FAIL_IF_QUIESCING + MQC.MQOO_INPUT_SHARED + MQC.MQCMD_CREATE_LISTENER);
    queueMessage.Format = MQC.MQFMT_STRING;
    queueGetMessageOptions = new MQGetMessageOptions();
    queue.Get(queueMessage, queueGetMessageOptions);
    strReturn = queueMessage.ReadString(queueMessage.MessageLength);
    queueManager.Disconnect();
    queue.Close();
    Method calling:
    Write:
    connectResp = operation.ConnectMQ(CustomMQ.queueManager, CustomMQ.host, CustomMQ.port, CustomMQ.channel);
    sendResp = operation.WriteQMsg(CustomMQ.inputQueueName, request);
    
    Read:
    connectResp = operation.ConnectMQ(CustomMQ.queueManager, CustomMQ.host, CustomMQ.port, CustomMQ.channel);
    response = operation.ReadQMsg(CustomMQ.outputQueueName);
