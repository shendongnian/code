    private void ReadFrame()
    {
        using (UdpClient socket = new UdpClient(this.camPort))
        {
            try
            {
                while (!end)
                {
                    var remoteEP = new IPEndPoint(IPAddress.Any, this.camPort);
                    byte[] data = socket.Receive(ref remoteEP);
                    Emgu.CV.CvInvoke.Imdecode(data, Emgu.CV.CvEnum.ImreadModes.ReducedColor8, this.Mat);
                }
            }
            catch (SocketException)
            {
                throw;
            }
        }
    }
