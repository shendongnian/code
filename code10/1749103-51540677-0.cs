    public abstract partial  class Connectable : Window
    {
        public abstract void Start();
        public abstract void Stop();
        public void WaitMessage()
        {
            WaitMessage(new StateObject() { socket = socket });
        }
        private void WaitMessage(StateObject so)
        {
            Socket s = so.socket;
            int read = s.Receive(so.buffer, 0, StateObject.BUFFER_SIZE, SocketFlags.None);
            so.sb.Append(Encoding.UTF8.GetString(so.buffer, 0, read));
            if (s.Available > 0)
                WaitMessage(so);
            else if (NewMessage != null)
            {
                NewMessage(so.sb.ToString());
                so.sb.Clear();
            }
        }
        public void ReceiveMessage()
        {
            StateObject state = new StateObject() { socket = socket };
            try { socket.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(MessageReceived), state); }
            catch (SocketException e) { Console.WriteLine(e.Message); }
        }
        protected void MessageReceived(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState;
            Socket s = so.socket;
            int read = s.EndReceive(ar);
            so.sb.Append(Encoding.UTF8.GetString(so.buffer, 0, read));
            if (s.Available > 0)
                s.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(MessageReceived), so);
            else if (NewMessage != null)
            {
                NewMessage(so.sb.ToString());
                so.sb.Clear();
            }
        }
        public void SendMessage(string msg)
        {
            if (socket != null)
            {
                if (socket.Connected && !string.IsNullOrEmpty(msg))
                {
                    socket.Send(Encoding.UTF8.GetBytes(msg));
                }
            }
        }
        protected void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public virtual bool IsConnected()
        {
            if (socket == null)
                return false;
            return socket.Connected;
        }
        #region Members
        protected Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Message NewMessage;
        #endregion
        #region Delegates
        public delegate void Message(string message);
        #endregion
    }
