    public class MessageEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
    public partial class Form2 : Form
    {
        public event EventHandler<MessageEventArgs> Button1Click;
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler handler = Button1Click;
            if (handler != null)
            {
                handler(this, new MessageEventArgs(txtMessage.Text));
            }
        }
    }
