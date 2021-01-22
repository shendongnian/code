    interface IMessage
    {
    }
    class LoginMessage : IMessage
    {
    }
    class LogoutMessage : IMessage
    {
    }
    class UnknownMessage : IMessage
    {
    }
    interface IMessageProcessor
    {
        void PrcessMessageBase(IMessage msg);
    }
    abstract class MessageProcessor<T> : IMessageProcessor where T : IMessage
    {
        public void PrcessMessageBase(IMessage msg)
        {
            ProcessMessage((T)msg);
        }
        
        public abstract void ProcessMessage(T msg);
    }
    class LoginMessageProcessor : MessageProcessor<LoginMessage>
    {
        public override void ProcessMessage(LoginMessage msg)
        {
            System.Console.WriteLine("Handled by LoginMsgProcessor");
        }
    }
    class LogoutMessageProcessor : MessageProcessor<LogoutMessage>
    {
        public override void ProcessMessage(LogoutMessage msg)
        {
            System.Console.WriteLine("Handled by LogoutMsgProcessor");
        }
    }
    class MessageProcessorTest
    {
        /// <summary>
        /// IMessage Type and the IMessageProcessor which would process that type.
        /// It can be further optimized by keeping IMessage type hashcode
        /// </summary>
        private Dictionary<Type, IMessageProcessor> msgProcessors = 
                                    new Dictionary<Type, IMessageProcessor>();
        bool processorsLoaded = false;
        public void EnsureProcessorsLoaded()
        {
            if(!processorsLoaded)
            {
                var processors =
                    from processorType in Assembly.GetExecutingAssembly().GetTypes()
                    where processorType.IsClass && !processorType.IsAbstract &&
                          processorType.GetInterface(typeof(IMessageProcessor).Name) != null
                    select Activator.CreateInstance(processorType);
                foreach (IMessageProcessor msgProcessor in processors)
                {
                    MethodInfo processMethod = msgProcessor.GetType().GetMethod("ProcessMessage");
                    msgProcessors.Add(processMethod.GetParameters()[0].ParameterType, msgProcessor);
                }
                processorsLoaded = true;
            }
        }
        public void ProcessMessages()
        {
            List<IMessage> msgList = new List<IMessage>();
            msgList.Add(new LoginMessage());
            msgList.Add(new LogoutMessage());
            msgList.Add(new UnknownMessage());
            foreach (IMessage msg in msgList)
            {
                ProcessMessage(msg);
            }
        }
        public void ProcessMessage(IMessage msg)
        {
            EnsureProcessorsLoaded();
            IMessageProcessor msgProcessor = null;
            if(msgProcessors.TryGetValue(msg.GetType(), out msgProcessor))
            {
                msgProcessor.PrcessMessageBase(msg);
            }
            else
            {
                System.Console.WriteLine("Processor not found");
            }
        }
        public static void Test()
        {
            new MessageProcessorTest().ProcessMessages();
        }
    }
