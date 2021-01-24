    byte[] newLine = Encoding.ASCII.GetBytes(Environment.NewLine);   
    byte[] password2 = ASCIIEncoding.ASCII.GetBytes(password);
    Console.WriteLine("Sending : " + password);
    nwStream.Write(password2, 0, password2.Length); //sending packet
    nwStream.Write(newLine,0,newLine.Length);
