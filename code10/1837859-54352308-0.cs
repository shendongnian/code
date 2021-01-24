    public string Read()
    {
        var data = new byte[1024];
        var received = "";
        var size = _networkStream.Read(data, 0, data.Length);
        if(size == 0)
            return null;
        received = Encoding.ASCII.GetString(data, 0, size);
        return received;
    }
