    using System;
    using System.Net;
    using System.Net.Sockets;
    /// <summary>
    /// Extensions to Socket class
    /// </summary>
    public static class SocketExtensions
    {
        /// <summary>
        /// Connects the specified socket.
        /// </summary>
        /// <param name="socket">The socket.</param>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="timeout">The timeout.</param>
        public static void Connect(this Socket socket, string host, int port, TimeSpan timeout)
        {
            AsyncConnect(socket, (s, a, o) => s.BeginConnect(host, port, a, o), timeout);
        }
        /// <summary>
        /// Connects the specified socket.
        /// </summary>
        /// <param name="socket">The socket.</param>
        /// <param name="addresses">The addresses.</param>
        /// <param name="port">The port.</param>
        /// <param name="timeout">The timeout.</param>
        public static void Connect(this Socket socket, IPAddress[] addresses, int port, TimeSpan timeout)
        {
            AsyncConnect(socket, (s, a, o) => s.BeginConnect(addresses, port, a, o), timeout);
        }
        /// <summary>
        /// Asyncs the connect.
        /// </summary>
        /// <param name="socket">The socket.</param>
        /// <param name="connect">The connect.</param>
        /// <param name="timeout">The timeout.</param>
        private static void AsyncConnect(Socket socket, Func<Socket, AsyncCallback, object, IAsyncResult> connect, TimeSpan timeout)
        {
            var asyncResult = connect(socket, null, null);
            if (!asyncResult.AsyncWaitHandle.WaitOne(timeout))
            {
                try
                {
                    socket.EndConnect(asyncResult);
                }
                catch (SocketException)
                { }
                catch (ObjectDisposedException)
                { }
            }
        }
