    public class StateObject
    {
        public const int DEFAULT_SIZE = 1024;           //size of receive buffer
        public byte[] buffer = new byte[DEFAULT_SIZE];  //receive buffer
        public int dataSize = 0;                        //data size to be received
        public bool dataSizeReceived = false;           //received data size?
        public StringBuilder sb = new StringBuilder();  //received data String
        public int dataRecieved = 0;
        public Socket workSocket = null;                //client socket.
        public DateTime TimeStamp;                      //timestamp of data
    } //end class StateObject
