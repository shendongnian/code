    public partial class Form1 : Form
    {
        private readonly CallReceiver _callReceiver;
        private DisplayCallForm _displayCallForm;
        public Form1(CallReceiver callReceiver)
        {
            _callReceiver = callReceiver;
            InitializeComponent();
            _callReceiver.CallReceived += CallReceiverOnCallReceived;
            
        }
        private void CallReceiverOnCallReceived(object sender, int i)
        {
            
            this.InvokeIfRequired(() =>
            {
                if (_displayCallForm == null)
                {
                    _displayCallForm = new DisplayCallForm(_callReceiver);
                    _displayCallForm.Show(this); //give "this" to show() to make sure the 
                                                 //new dialog is in foreground.
                }
            });
        }
    }
