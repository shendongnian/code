    public partial class DisplayCallForm : Form
    {
        private readonly CallReceiver _callReceiver;
        public DisplayCallForm(CallReceiver callReceiver)
        {
            
            InitializeComponent();
            _callReceiver = callReceiver;
            _callReceiver.CallReceived += CallReceiverOnCallReceived;
        }
        private void CallReceiverOnCallReceived(object sender, int i)
        {
            this.InvokeIfRequired(() =>
            {
                label1.Text = i.ToString();
            });
        }
    }
