    // Save your connection globally so that you can
    // access it in your button clicks etc...
    Socket client;
    
    public Form1()
    {
    	InitializeComponent();
    	InitializeClient();
    }
    
    private void InitializeClient()
    {
    	client = IO.Socket("http://localhost");
        client.On(Socket.EVENT_CONNECT, () =>
        {
            UpdateStatus("Connected");
        });
        client.On(Socket.EVENT_DISCONNECT, () =>
        {
            UpdateStatus("disconnected");
        });
    }
    
    private void btnSend_Click(object sender, EventArgs e)
    {
        String clientMsg = txtSend.Text;
        if (ClientMsg.Length == 0)
        {
        	// No need to clear, its already empty
            return;
        }
        else
        {
        	// Send the message here
            client.Emit("admin", clientMsg);
            lstMsgs.Items.Add("You:" + " " + clientMsg);
            txtSend.Clear();
        }
    }
