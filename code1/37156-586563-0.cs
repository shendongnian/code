    TcpClient oC = new TcpClient(ip, port);
    oC = new TcpClient(ip, port);
    
    try {
       using (StreamWriter messageReader = new StreamReader(oC.GetStream(), Encoding.ASCII))
       {
           reply = messageReader.ReadLine();
       }
    }
