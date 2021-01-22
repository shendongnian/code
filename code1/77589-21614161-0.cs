    public void DoIt()
        {
            bool continueToSeekForMessages = true;
            while (continueToSeekForMessages)
            {
                try
                {
                    var messageQueue = new System.Messaging.MessageQueue(@"FormatName:Direct=OS:MyComputerNameHere\Private$\MyPrivateQueueNameHere");
                    var message = messageQueue.Receive(new TimeSpan(0, 0, 3));
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                    var messageBody = message.Body;
                }
                catch (Exception ex)
                {
                    continueToSeekForMessages = false;
                }
            }
        }
