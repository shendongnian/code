    public void BuildPcfMessage(IBM.WMQ.PCF.PCFMessage pcfMessage) {
      IBM.WMQ.PCF.PCFParameter[] pcfParameters = pcfMessage.GetParameters();
      afflictedQueueManager = pcfParameters[0].GetValue().ToString();
      afflictedQueue = pcfParameters[1].GetValue().ToString();
    }
