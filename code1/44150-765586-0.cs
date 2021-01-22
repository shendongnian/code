    public class WS2
    {
        public static Socket sock;
        public static byte[] data = new byte[8096];
        public static int server = 0;
        public static bool forced = true;
        public static void Close()
        {
            //Extern.closesocket(sock.Handle.ToInt32());
            //Extern.WSACleanup();
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
            if (forced)
            {
                Connect();
            }
        }
        public static void ConnectTo(string ip,int port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ip, port);
            int handle = 0;
            var form1 = Form.ActiveForm as FormMain;
            if (form1 != null)
                handle = form1.GetHandle;
            if (handle == 0)
            {
                FormMain.PerformActionOnMainForm(form => form.memo.Text += "An error occured: Error code WS_01_ASYNC_HANDLE");
                return;
            }
            Extern.WSAAsyncSelect(sock.Handle.ToInt32(), handle, Values.MESSAGE_ASYNC, Values.FD_READ | Values.FD_CLOSE);
        }
        public static void Connect()
        {
            //Get IP && port
            string ip = GetIPFromHost("gwgt1.joymax.com");
            if (ip == "")
            {
                ip = GetIPFromHost("gwgt2.joymax.com");
                if (ip == "")
                {
                }
                server +=2;
            }
            else
                server +=1;
            int port = 15779;
            //
            ConnectTo(ip, port);
        }
        public static void Receive()
        {
            int size = sock.Receive(data);
            if (size == 0)
            {
                FormMain.PerformActionOnMainForm(form => form.memo.Text += "An error occured: Error Code WS_02_RECV_BEGN");
            }
            Main.Handle(data, size);
        }
        public static string GetIPFromHost(string HostName)
        {
            IPHostEntry ip;
            try
            {
                ip = Dns.GetHostEntry(HostName);
            }
            catch (Exception)
            {
                return "";
            }
            return ip.AddressList[0].ToString();
        }
    }
