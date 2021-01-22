    using System;
    using System.Net.Sockets;
    using System.Threading;
    /// <summary>
    /// Extensions to TcpListener
    /// </summary>
    public static class TcpListenerExtensions
    {
        /// <summary>
        /// Accepts a pending connection request.
        /// </summary>
        /// <param name="tcpListener">The TCP listener.</param>
        /// <returns>
        /// A <see cref="T:System.Net.Sockets.Socket" /> used to send and receive data.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The listener has not been started with a call to <see cref="M:System.Net.Sockets.TcpListener.Start" />.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public static Socket AcceptSocket2(this TcpListener tcpListener)
        {
            Socket socket = null;
            var clientConnected = new ManualResetEvent(false);
            clientConnected.Reset();
            tcpListener.BeginAcceptSocket(delegate(IAsyncResult asyncResult)
            {
                try
                {
                    socket = tcpListener.EndAcceptSocket(asyncResult);
                }
                catch (ObjectDisposedException)
                { }
                clientConnected.Set();
            }, null);
            clientConnected.WaitOne();
            return socket;
        }
    }
