    internal class MessageHandler : Form
    {
        public event EventHandler<MessageData> MessageReceived;
        public MessageHandler ()
        {
            SuspendLayout();
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HiddenForm";
            Text = "HiddenForm";
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            ResumeLayout(false);
        }
        // This ensures that the window is truly hidden
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
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
            Application.Run(messageHandler);
        }
    }
