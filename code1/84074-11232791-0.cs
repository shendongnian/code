    public void save(){
        mapSettings();
        Settings.Default.Save();
    }
    private void mapSettings(){
        Settings.Default.BaudRate = baudRate;
        Settings.Default.COMPort = port;
        Settings.Default.DataBits = dataBits;
        Settings.Default.Handshake = handshake;
        Settings.Default.Parity = parity;
        Settings.Default.ReadTimeout = readTimeout;
        Settings.Default.WriteTimeout = writeTimeout;
        Settings.Default.CommunicationTimeout = communicationTimeout;
    }
