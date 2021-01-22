    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.Threading;
    using System.Diagnostics;
    
    
    namespace Chat
    {
        public partial class Form1 : Form
        {
            
    
            public bool contfunctioning = true; public bool changedsplay = false; public bool setupntwrk = false;
            public string enteredchats, msg, chatstring, Chats, lastchatstring;
            
            UdpClient subscriber = new UdpClient(8899);
            UdpClient publisher = new UdpClient("230.0.0.100", 8898);
    
            System.Windows.Forms.Timer timer1use = new System.Windows.Forms.Timer();
            
            
    
            public Form1()
            {
                InitializeComponent();
            }
    
    
    
            private void btnConnect_Click(object sender, EventArgs e)
            {
                Thread rcvchats = new Thread(ReceiveChats);
                rcvchats.Start();
                
                timer1use.Interval = 1000;
                timer1use.Start();
            }
    
            private void btnSend_Click(object sender, EventArgs e)
            {
                enteredchats = txtboxUsr.Text + ": " + txtboxentertxt.Text;
                txtboxentertxt.Clear();
    
                msg = String.Format(enteredchats);
                byte[] sdata = Encoding.ASCII.GetBytes(msg);
                publisher.Send(sdata, sdata.Length);
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (chatstring != lastchatstring)
                dsplay.AppendText("\r\n" + chatstring);
    
                lastchatstring = chatstring;
    
                
            }
    
            public void ReceiveChats()
            {
                while (true)
                {
                    if (setupntwrk == false)
                    {
                        string ConnectIPAddress;
                        ConnectIPAddress = txtboxIP.Text;
                        IPAddress addr = IPAddress.Parse(ConnectIPAddress);
                        MessageBox.Show("Subscribing to chat server on " + ConnectIPAddress + ".", ConnectIPAddress);
                        subscriber.JoinMulticastGroup(addr);
    
                        setupntwrk = true;
                    }
    
                    IPEndPoint ep = null;
                    chatstring = Encoding.ASCII.GetString(subscriber.Receive(ref ep));
    
                    Thread.Sleep(1000);
                }
    
            }
    
            private void btnHost_Click(object sender, EventArgs e)
            {
                Process starthost = new Process();
                starthost.StartInfo.FileName = "C:\\ChatServ.exe";
                starthost.Start();
                
            }
        }
    }
