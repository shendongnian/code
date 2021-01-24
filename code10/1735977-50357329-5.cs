    class CommunicationSettings
    {
      private int port;
      private int updateInterval;
      private int baudRate;
      private int bits;
      private int stopBits;
      private bool parity;
      public int Port { get { return port; } set { port = value; } }
      public int UpdateInterval { get { return updateInterval; } set { updateInterval = value; } }
      public int BaudRate { get { return baudRate; } set { baudRate = value; } }
      public int Bits { get { return bits; } set { bits = value; } }
      public int StopBits { get { return stopBits; } set { stopBits = value; } }
      public bool Parity { get { return parity; } set { parity = value; } }
      static CommunicationSettings _TheSettings = null;
      public static CommunicationSettings TheSettings
      {
        get
        {
          if (_TheSettings == null)
          {
            _TheSettings = new CommunicationSettings();
          }
          return _TheSettings;
        }
      }
    }
