    System.Net.Sockets.TcpClient t = new System.Net.Sockets.TcpClient ("yourmachineHOST", 13);
    System.IO.StreamReader rd = new System.IO.StreamReader (t.GetStream ()); 
    Console.WriteLine (rd.ReadToEnd ());
    rd.Close();
    t.Close();
