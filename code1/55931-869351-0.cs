    Socket MySocket;
    Socket ResponceSocket;
    byte[] Request;
    byte[] Responce;
    public byte[] GetUDPResponce()
    {
        this.MySocket.Send(Request).To(ResponceSocket);
        this.MySocket.Receive(Responce).From(ResponceSocket);
        return Responce;
    }
