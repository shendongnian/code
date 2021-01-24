    using DevExpress.XtraEditors;
    using SuperWebSocket;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    namespace WebSocketServer
    {
        public partial class Server : UserControl
        {
            WebSocket server;
            WebSocketSession session;
            public Server()
            {
                InitializeComponent();
            
                server = new WebSocket();
                server.ServerStarted += Server_ServerStarted;
                server.ServerStopped += Server_ServerStopped;
                server.MessageReceived += Server_MessageReceived;
            }
            private void Server_MessageReceived(object sender, EventArgs e)
            {
                MessageReceivedEventArgs eventArgs = (MessageReceivedEventArgs)e;
                /* save session */
                this.session = eventArgs.Session;
                this.Log("SessionID: " + session.RemoteEndPoint.ToString() + "; Message: " + eventArgs.Message);
                /* send back the message to the client */
                this.session.Send(eventArgs.Message); //comment out if needed
            }
            private void Server_ServerStopped(object sender, EventArgs e)
            {
                this.Log("Server stopped!");
            }
            private void Server_ServerStarted(object sender, EventArgs e)
            {
                if ((e as WebSocketServerEventArgs).Success)
                {
                    this.Log("Server started on ws://" + server.IP + ":" + server.Port + "/");
                }
                else
                    this.Log("Can't start the server!");
            }
            private void Log(string message)
            {
                /* here, this.log is a TextBox */
                if (this.log.InvokeRequired)
                    this.log.Invoke((MethodInvoker)delegate
                    {
                        this.log.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " > " + message + Environment.NewLine;
                    });
                else
                {
                    this.log.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " > " + message + Environment.NewLine;
                }
            }
            /* a button to start the server */
            private void BtnStart_Click(object sender, EventArgs e) => server.Start();
            /* a button to stop the server */
            private void BtnStop_Click(object sender, EventArgs e) => server.Stop();
            /* a button to send a message from a TextBox to the client */
            private void BtnSend_Click(object sender, EventArgs e)
            {
                if (this.txtMessage.Text != string.Empty)
                    this.SendMessage(this.txtMessage.Text);
            }
            private void SendMessage(string message)
            {
                try
                {
                    /* use current session to send the message */
                    this.session.Send(message);
                    this.Log("Message: " + message + " sent to client!");
                }
                catch (Exception e)
                {
                    this.Log(e.Message);
                }
            }
        }
    }
