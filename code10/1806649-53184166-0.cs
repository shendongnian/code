     await Task.Factory.StartNew(async () =>
                {
                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.200.111"), 23);
                    Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    S.Connect(ip);
                    S.Send(Encoding.UTF8.GetBytes("SS" + Environment.NewLine));
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        if (S.Available != 0)
                        {
                            S.Receive(buffer);
                            Debug.WriteLine(Encoding.UTF8.GetString(buffer));
                            Debug.WriteLine("");
                            await Task.Delay(100);
                        }
                    }
                });
