    public partial class AlertBox : Form
    {
        public AlertBox()
        {
            InitializeComponent();
        }
        private MessageUpdater _messageUpdater = null;
        public MessageUpdater MessageUpdater
        {
            set
            {
                if (_messageUpdater != null)
                {
                    _messageUpdater.MessageSent -= UpdateMessage;
                }
                if (value != null)
                {
                    _messageUpdater = value;
                    _messageUpdater.MessageSent += UpdateMessage;
                }
            }
        }
        private void UpdateMessage(object sender, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() => this.UpdateMessage(sender, message)));
            }
            else
            {
                this.MessageLabel.Text = message;
            }
        }
    }
