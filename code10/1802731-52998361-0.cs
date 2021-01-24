    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Dummy
    {
        public partial class Form1 : Form
        {
            TcpListener listener;
            byte[] bufferRx;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                int port = 9982;
                listener = new TcpListener(IPAddress.Any, port);
                listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                listener.Start();
    
                //Begin to start the first connection
                System.Console.WriteLine("Waitting for client");
                listener.BeginAcceptTcpClient(BeginListeningInBackground, listener);
            }
    
            private void BeginListeningInBackground(IAsyncResult asyncResult)
            {
                System.Console.WriteLine("new for client request.");
                var listener = asyncResult.AsyncState as TcpListener;
                var tcpClient = listener.EndAcceptTcpClient(asyncResult);
    
                BeginToReadOnCLient(tcpClient);
    
                System.Console.WriteLine("Waitting for next client");
                listener.BeginAcceptTcpClient(BeginListeningInBackground, listener);
    
            }
    
            private void BeginToReadOnCLient(TcpClient client)
            {
                System.Console.WriteLine("Initi Rx on Client");
    
                NetworkStream ns = client.GetStream();
                bufferRx = new byte[10];
                ns.BeginRead(bufferRx, 0, 10, ReadFromClientStream, ns);// (BeginListeningInBackground, listener);
            }
    
            private void ReadFromClientStream(IAsyncResult asyncResult)
            {
                NetworkStream ns = (NetworkStream)asyncResult.AsyncState;
                System.Console.WriteLine("Read Data from client. DATA:[" + System.Text.Encoding.Default.GetString(bufferRx) + "]");
                bufferRx = new byte[10];
                ns.BeginRead(bufferRx, 0, 10, ReadFromClientStream, ns);
            }
        }
    }
