        ConnType ConnType
        {
            get;
            set;
        }
        bool Connected
        {
            get;
        }
        int Id
        {
            get;
            set;
        }
        void Connect();
        void Disconnect();
        void Write(string Data);
        string Read();
        string ReadOnByte(int Lenght, char EndChar);
        String ReadBuffer();
        void ClearBuffer();
        string ReadAll();
        event EventHandler EvtOnConnect;
        event EventHandler EvtOnDisconnect;
        event EventHandler<EventArgs.OnDataReceivedEventArgs> EvtOnDataReceived;
    }
