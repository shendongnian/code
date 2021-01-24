    public partial class Form1 : Form
    {
        private readonly WebSocket _client;
        public Form1()
        {
            InitializeComponent();
            _client = new WebSocket("ws://echo.websocket.org");
            _client.OnMessage += Ws_OnMessage;
            _client.OnError += Ws_OnError;
            _client.Connect();
        }
        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
        }
        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            _client.Send("Hi");
        }
    }
