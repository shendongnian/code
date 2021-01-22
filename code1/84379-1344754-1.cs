    Socket sock = GetSocket();
    State state = new State() { Socket = sock, Buffer = new byte[1024], ThirdPartyControl = GetControl() };
    sock.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ProcessAsyncReceive, state);
    void ProcessAsyncReceive(IAsyncResult iar)
    {
        State state = iar.AsyncState as State;
        state.Socket.EndReceive(iar);
        // Process the received data in state.Buffer here
        state.ThirdPartyControl.ScrapeScreen(state.Buffer);
        state.Socket.BeginReceive(state.buffer, 0, state.Buffer.Length, 0, ProcessAsyncReceive, iar.AsyncState);
    }
    public class State
    {
        public Socket Socket { get; set; }
        public byte[] Buffer { get; set; }
        public ThirdPartyControl { get; set; }
    }
