    namespace TestClient
    {
        public partial class Form1 : Form
        {
    
            SocketClient client = new SocketClient();
    
            public Form1()
            {
                InitializeComponent();
    
                client.Message += Client_Message;
            }
    
            private void Client_Message(object sender, MessageEventArgs e)
            {
                label1.Invoke(new Action() => label1.Text = e.Message);
            }
            // your other code
        }
    }
