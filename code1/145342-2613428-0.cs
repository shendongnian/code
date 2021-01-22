    UdpClient udpClient = new UdpClient(11000); //sourceport
    try{
         udpClient.Connect("www.contoso.com", 11000); //'connect' to destmachine and port
         // Sends a message to the host to which you have connected.
         Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
         udpClient.Send(sendBytes, sendBytes.Length);
