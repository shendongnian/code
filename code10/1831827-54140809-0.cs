    private static IDisposable Subscribe(ISession session, IQueue queue, Action<IMessage> messageCallback)
    {
        var flowProps = new FlowProperties()
        {
            AckMode = MessageAckMode.ClientAck,
            MaxUnackedMessages = 1
        };
        return session.CreateFlow(flowProps, queue, null, HandleMessage, HandleFlowEvent);
        void HandleMessage(object sender, MessageEventArgs messageEvent)
        {
            messageCallback(messageEvent.Message);
        }
        void HandleFlowEvent(object sender, FlowEventArgs sessionEvent)
        {
            /*log something*/
        }
    }
