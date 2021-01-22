    var socket = new System.Net.Sockets.TcpClient();
                socket.NoDelay = true;
                socket.Connect(uri.Host, port);
                var ns = socket.GetStream();
                int timeout = 500; //ms
                DateTime lastReceived = DateTime.Now;
                string buffer = "";
                while (true)
                {
                    if (ns.DataAvailable)
                    {
                        var b = ns.ReadByte();
                        buffer += b + ", "; //customise this line yourself
                        lastReceived = DateTime.Now;
                        continue;
                    }
                    if (lastReceived.AddMilliseconds(timeout) < DateTime.Now) break;
                    System.Threading.Thread.Sleep(timeout / 5);
                }
