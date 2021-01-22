    internal class MessageHandler : NativeWindow
    {
        public event EventHandler<MessageData> MessageReceived;
        public MessageHandler ()
        {
            CreateHandle(new CreateParams());
        }
        protected override void WndProc(ref Message msg)
        {
            // filter messages here for your purposes
            EventHandler<MessageData> = MessageReceived;
            if (handler != null) handler(ref msg);
            base.WndProc(ref msg);
        }
    }
    public class MessagePumpManager
    {
        private readonly Thread messagePump;
        private AutoResetEvent messagePumpRunning = new AutoResetEvent(false);
        public StartMessagePump()
        {
            // start message pump in its own thread
            messagePump = new Thread(RunMessagePump) {Name = "ManualMessagePump"};
            messagePump.Start();
            messagePumpRunning.WaitOne();
        }
        
        // Message Pump Thread
        private void RunMessagePump()
        {
            // Create control to handle windows messages
            messageHandler = new MessageHandler();
            // Initialize 3rd party dll 
            DLL.Init(messageHandler.Handle);
            Console.WriteLine("Message Pump Thread Started");
            messagePumpRunning.Set();
            Application.Run();
        }
    }
