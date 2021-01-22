    // Project: Salient
    // http://salient.codeplex.com
    // Date: April 16 2010
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Threading;
    using Microsoft.VisualStudio.WebHost;
    namespace Salient.Excerpts
    {
        /// <summary>
        /// A general purpose Microsoft.VisualStudio.WebHost.Server test fixture.
        /// WebHost.Server is the core of the Visual Studio Development Server (WebDev.WebServer).
        ///
        /// This server is run in-process and may be used in F5 debugging.
        /// </summary>
        /// <remarks>
        /// If you are adding this source code to a new project, You will need to
        /// manually add a reference to WebDev.WebHost.dll to your project. It cannot
        /// be added from within Visual Studio.
        ///
        /// Please see the Readme.txt accompanying this code for details.
        /// </remarks>
        /// NOTE: code from various namespaces/classes in the Salient project have been merged into this
        /// single class for this post in the interest of brevity
        public class WebHostServer
        {
            private Server _server;
            public string ApplicationPath { get; private set; }
            public string HostName { get; private set; }
            public int Port { get; private set; }
            public string VirtualPath { get; private set; }
            public string RootUrl
            {
                get { return string.Format(CultureInfo.InvariantCulture, "http://{0}:{1}{2}", HostName, Port, VirtualPath); }
            }
            /// <summary>
            /// Combine the RootUrl of the running web application with the relative url specified.
            /// </summary>
            public virtual Uri NormalizeUri(string relativeUrl)
            {
                return new Uri(RootUrl + relativeUrl);
            }
            /// <summary>
            /// Will start "localhost" on first available port in the range 8000-10000 with vpath "/"
            /// </summary>
            /// <param name="applicationPath"></param>
            public void StartServer(string applicationPath)
            {
                StartServer(applicationPath, GetAvailablePort(8000, 10000, IPAddress.Loopback, true), "/", "localhost");
            }
            /// <summary>
            /// </summary>
            /// <param name="applicationPath">Physical path to application.</param>
            /// <param name="port">Port to listen on.</param>
            /// <param name="virtualPath">Optional. defaults to "/"</param>
            /// <param name="hostName">Optional. Is used to construct RootUrl. Defaults to "localhost"</param>
            public void StartServer(string applicationPath, int port, string virtualPath, string hostName)
            {
                if (_server != null)
                {
                    throw new InvalidOperationException("Server already started");
                }
                // WebHost.Server will not run on any other IP
                IPAddress ipAddress = IPAddress.Loopback;
                if(!IsPortAvailable(ipAddress, port))
                {
                    throw new Exception(string.Format("Port {0} is in use.", port));
                }
                applicationPath = Path.GetFullPath(applicationPath);
                virtualPath = String.Format("/{0}/", (virtualPath ?? string.Empty).Trim('/')).Replace("//", "/");
                _server = new Server(port, virtualPath, applicationPath, false, false);
                _server.Start();
                ApplicationPath = applicationPath;
                Port = port;
                VirtualPath = virtualPath;
                HostName = string.IsNullOrEmpty(hostName) ? "localhost" : hostName;
            }
            /// <summary>
            /// Stops the server.
            /// </summary>
            public void StopServer()
            {
                if (_server != null)
                {
                    _server.Stop();
                    _server = null;
                    // allow some time to release the port
                    Thread.Sleep(100);
                }
            }
            public void Dispose()
            {
                StopServer();
            }
           /// <summary>
            /// Gently polls specified IP:Port to determine if it is available.
            /// </summary>
            /// <param name="ipAddress"></param>
            /// <param name="port"></param>
            public static bool IsPortAvailable(IPAddress ipAddress, int port)
            {
                bool portAvailable = false;
                for (int i = 0; i < 5; i++)
                {
                    portAvailable = GetAvailablePort(port, port, ipAddress, true) == port;
                    if (portAvailable)
                    {
                        break;
                    }
                    // be a little patient and wait for the port if necessary,
                    // the previous occupant may have just vacated
                    Thread.Sleep(100);
                }
                return portAvailable;
            }
            /// <summary>
            /// Returns first available port on the specified IP address.
            /// The port scan excludes ports that are open on ANY loopback adapter.
            ///
            /// If the address upon which a port is requested is an 'ANY' address all
            /// ports that are open on ANY IP are excluded.
            /// </summary>
            /// <param name="rangeStart"></param>
            /// <param name="rangeEnd"></param>
            /// <param name="ip">The IP address upon which to search for available port.</param>
            /// <param name="includeIdlePorts">If true includes ports in TIME_WAIT state in results.
            /// TIME_WAIT state is typically cool down period for recently released ports.</param>
            /// <returns></returns>
            public static int GetAvailablePort(int rangeStart, int rangeEnd, IPAddress ip, bool includeIdlePorts)
            {
                IPGlobalProperties ipProps = IPGlobalProperties.GetIPGlobalProperties();
                // if the ip we want a port on is an 'any' or loopback port we need to exclude all ports that are active on any IP
                Func<IPAddress, bool> isIpAnyOrLoopBack = i => IPAddress.Any.Equals(i) ||
                                                               IPAddress.IPv6Any.Equals(i) ||
                                                               IPAddress.Loopback.Equals(i) ||
                                                               IPAddress.IPv6Loopback.
                                                                   Equals(i);
                // get all active ports on specified IP.
                List<ushort> excludedPorts = new List<ushort>();
                // if a port is open on an 'any' or 'loopback' interface then include it in the excludedPorts
                excludedPorts.AddRange(from n in ipProps.GetActiveTcpConnections()
                                       where
                                           n.LocalEndPoint.Port >= rangeStart &&
                                           n.LocalEndPoint.Port <= rangeEnd && (
                                           isIpAnyOrLoopBack(ip) || n.LocalEndPoint.Address.Equals(ip) ||
                                            isIpAnyOrLoopBack(n.LocalEndPoint.Address)) &&
                                            (!includeIdlePorts || n.State != TcpState.TimeWait)
                                       select (ushort)n.LocalEndPoint.Port);
                excludedPorts.AddRange(from n in ipProps.GetActiveTcpListeners()
                                       where n.Port >= rangeStart && n.Port <= rangeEnd && (
                                       isIpAnyOrLoopBack(ip) || n.Address.Equals(ip) || isIpAnyOrLoopBack(n.Address))
                                       select (ushort)n.Port);
                excludedPorts.AddRange(from n in ipProps.GetActiveUdpListeners()
                                       where n.Port >= rangeStart && n.Port <= rangeEnd && (
                                       isIpAnyOrLoopBack(ip) || n.Address.Equals(ip) || isIpAnyOrLoopBack(n.Address))
                                       select (ushort)n.Port);
                excludedPorts.Sort();
                for (int port = rangeStart; port <= rangeEnd; port++)
                {
                    if (!excludedPorts.Contains((ushort)port))
                    {
                        return port;
                    }
                }
                return 0;
            }
        }
    }
