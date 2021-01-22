    public class WinSock {
    
        private Socket _socket;
        private byte[] _data;
    
        public Socket Socket {
           get { return _socket; }
        }
    
        public byte[] Data() {
            get { return _data; }
        }
    
    }
