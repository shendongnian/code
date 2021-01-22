        static IObservable<string> GetMessages(Socket socket, IPAddress addr, int port)
        {
            return Observable.CreateWithDisposable<string>(
                o =>
                {
                    byte[] buffer = new byte[1024];
                    Action<int, Action<int>> readIntoBuffer = (length, callback) =>
                    {
                        var totalRead = 0;
                        AsyncCallback receiveCallback = null;
                        AsyncCallback temp = r =>
                        {
                            var read = socket.EndReceive(r);
                            if (read == 0)
                            {
                                socket.Close();
                                o.OnCompleted();
                                return;
                            }
                            totalRead += read;
                            if (totalRead < length)
                            {
                                socket.BeginReceive(buffer, totalRead, length - totalRead, SocketFlags.None, receiveCallback, null);
                            }
                            else
                            {
                                callback(length);
                            }
                        };
                        receiveCallback = temp;
                        socket.BeginReceive(buffer, totalRead, length, SocketFlags.None, receiveCallback, null);
                    };
                    Action<int> sizeRead = null;
                    Action<int> messageRead = x =>
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, x);
                        o.OnNext(message);
                        readIntoBuffer(4, sizeRead);
                    };
                    Action<int> temp2 = x =>
                    {
                        var size = BitConverter.ToInt32(buffer, 0);
                        readIntoBuffer(size, messageRead);
                    };
                    sizeRead = temp2;
                    AsyncCallback connectCallback = r =>
                    {
                        socket.EndConnect(r);
                        readIntoBuffer(4, sizeRead);
                    };
                    socket.BeginConnect(addr, port, connectCallback, null);
                    return socket;
                });
        }
