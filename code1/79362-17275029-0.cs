    //internal because only used for test code
    internal class SocketWrapper : Socket, ISocket
    {
        /// <summary>
        /// Web Socket
        /// </summary>
        public SocketWrapper():base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
        }
        //use all features of base Socket
    }
