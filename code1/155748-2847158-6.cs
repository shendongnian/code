    public partial class MainUI : Form
    {
        private IMessageListener _messageListener;
    
        public MainUI()
        {
            InitializeComponent();
            _messageListener = new MyListener();
            _messageListener.MessageReceived += MessageListener_MessageReceived;
        }
    
        void MessageListener_MessageReceived(object sender, MessageEventArgs e)
        {
            _messageListBox.Items.Add(e.Message.Text);
        }
    }
