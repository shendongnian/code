    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace FastListener
    {
        /// <summary>
        /// Example position class, replace with a real definition
        /// </summary>
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    
        /// <summary>
        /// Needed to be able to pass socket/buffer info
        /// between asynchronous requests.
        /// </summary>
        public struct ClientContext
        {
            public Socket socket;
            public byte[] buffer;
        }
    
        class Program
        {
            /// <summary>
            /// Positions received from mobile clients but not yet saved
            /// into the database.
            /// </summary>
            private readonly Queue<Position> _positions = new Queue<Position>();
    
            /// <summary>
            /// Number of threads currently saving stuff to the database.
            /// </summary>
            private int _poolThreads;
    
            /// <summary>
            /// Maximum number of threads that can save info to the database.
            /// </summary>
            private const int MaxThreads = 10;
    
            static void Main(string[] args)
            {
                new Program().Start();
            }
    
            private void Start()
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 1343);
                listener.Start(50);
                listener.BeginAcceptSocket(OnAccept, listener);
            }
    
            // Listener got a new connection
            private void OnAccept(IAsyncResult ar)
            {
                TcpListener listener = (TcpListener) ar.AsyncState;
    
                // It's very important to start listening ASAP
                // since you'll have a lot of incoming connections.
                listener.BeginAcceptSocket(OnAccept, listener);
    
                // I recommend that you create a buffer pool to improve performance
                byte[] buffer = new byte[400];
    
                // Now accept the socket.
                Socket socket = listener.EndAcceptSocket(ar);
                StartRead(new ClientContext {buffer = buffer, socket = socket});
            }
    
            private void StartRead(ClientContext context)
            {
                // start reading from the client.
                context.socket.BeginReceive(context.buffer, 0, 400, SocketFlags.None, OnReceive, context);
            }
    
    
            // Stuff from a client.
            private void OnReceive(IAsyncResult ar)
            {
                ClientContext context = (ClientContext) ar.AsyncState;
    
                int bytesRead = context.socket.EndReceive(ar);
                if (bytesRead == 0)
                {
                    // Put the buffer back in the pool
                    context.socket.Close();
                    return;
                }
    
                // convert bytes to position.
                // i'll just fake that here.
                Position pos = new Position();
    
                // Either handle the request directly
                if (_poolThreads < MaxThreads)
                    ThreadPool.QueueUserWorkItem(SaveToDatabase, pos);
                else
                {
                    // Or enqueue it to let a already active
                    // thread handle it when done with the previous position
                    lock (_positions)
                        _positions.Enqueue(pos);
                }
                // Don't forget to read from the client again
                StartRead(context); 
            }
    
            // will save stuff to the database.
            private void SaveToDatabase(object state)
            {
                // Could use Interlocked.Increment, but not really vital if 
                // one more more extra threads are saving to the db.
                ++_poolThreads; 
    
                Position position = (Position) state;
                while (true)
                {
                    // IMPLEMENT DB SAVE LOGIC HERE.
    
    
                    // check if another position is in the queue.
                    lock (_positions)
                    {
                        if (_positions.Count > 0)
                            position = _positions.Dequeue();
                        else
                            break; // jump out of the loop
                    }
                }
    
                --_poolThreads;
            }
        }
    }
