    public void server()
    {
        try
        {
            byte[] bytes = new byte[1024];
            IPAddress direction = IPAddress.Parse(getIPExternal()); //getIPExternal return the public IP of the machine in which the programm runs
            IPEndPoint directionPort = new IPEndPoint(direction, 5656);
            using (Socket socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socketServer.Bind(directionPort);
                socketServer.Listen(100);
                while (true)
                {
                    using (Socket client = socketServer.Accept())
                    {
                        int bytesReceived = client.Receive(bytes);
                        String message = System.Text.Encoding.Unicode.GetString(bytes, 0, bytesReceived);
                        editMultiline.Invoke(new writeMessageDelegate(writeMessage), new object[] { message, "client" }); //Ignore this, it is just to show the info in a textbox because the server code runs in a diferent thread
                        client.Shutdown(SocketShutdown.Both);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public string getIPExternal()
    {
        WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
        string direction;
        using (WebResponse response = request.GetResponse())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    direction = reader.ReadToEnd();
                }
            }
        }
        //Search for the ip in the html
        int first = direction.IndexOf("Address: ") + 9;
        int last = direction.LastIndexOf("</body>");
        return direction.Substring(first, last - first);
    }
