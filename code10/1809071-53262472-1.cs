    static char ACK = '\u0006';
    
    
    byte[] ackMsg = System.Text.Encoding.ASCII.GetBytes(ACK.ToString());
                                stream.Write(ackMsg, 0, ackMsg.Length);
