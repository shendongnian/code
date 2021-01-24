    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
     
    namespace ClientComputer
    {
        public partial class mainForm : Form
        {
            public mainForm()
            {
                InitializeComponent();
            }
            Socket hostSocket;
            Thread thread;
            string localIP = string.Empty;
            string computrHostName = string.Empty;
            private void mainForm_Load(object sender, EventArgs e)
            {
                computrHostName = Dns.GetHostName();
                IPHostEntry hostname = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in hostname.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                localIP = "127.0.0.1";
                this.Text = this.Text + " | " + localIP;
     
            }
            private void liveScreen_Click(object sender, EventArgs e)
            {
                connectSocket();
            }
     
            private void connectSocket()
            {
                Socket receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint hostIpEndPoint = new IPEndPoint(IPAddress.Parse(localIP), 10001);
                //Connection node
                receiveSocket.Bind(hostIpEndPoint);
                receiveSocket.Listen(10);
                MessageBox.Show("start");
                hostSocket = receiveSocket.Accept();
                thread = new Thread(new ThreadStart(trreadimage));
     
                thread.IsBackground = true;
                thread.Start();
            }
            private void trreadimage()
            {
                int dataSize;
                string imageName = "Image-" + System.DateTime.Now.Ticks + ".JPG";
                try
                {
     
                    dataSize = 0;
                    byte[] b = new byte[1024 * 10000];  //Picture of great
                    dataSize = hostSocket.Receive(b);
                    if (dataSize > 0)
                    {
                        MemoryStream ms = new MemoryStream(b);
                        Image img = Image.FromStream(ms);
                        img.Save(imageName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        videoBox.Image = img;
                        ms.Close();
                    }
     
                }
                catch (Exception ee)
                {
                    //MessageBox.Show(ee.Message);
                    //thread.Abort();
                }
                System.Threading.Thread.Sleep(1500);
                trreadimage();
            }
        }
    }
