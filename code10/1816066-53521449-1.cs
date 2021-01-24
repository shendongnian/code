    private void AcceptTCP()
    {
        while(true)
        {
          client = listener.AcceptTcpClient();
          ns = client.GetStream();
          Task Work = new Task(() => DoWork());
          Work.Start();
        }
    }
