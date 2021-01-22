        public static IObservable<T> GetSocketData<T>(this Socket socket, 
            int sizeToRead, Func<byte[],T> valueExtractor)
        {
            var readSize = Observable
                .FromAsyncPattern<byte[], int, int, SocketFlags, int>(
                socket.BeginReceive,
                socket.EndReceive);
            return Observable.CreateWithDisposable<T>(observer =>
            {
                var buffer = new byte[sizeToRead];
                return readSize(buffer, 0, sizeToRead, SocketFlags.None)
                    .Subscribe(
                    x => observer.OnNext(valueExtractor(buffer)),
                        observer.OnError,
                        observer.OnCompleted);
            });
        }
        public static IObservable<int> GetMessageSize(this Socket socket)
        {
            return socket.GetSocketData(4, buf => BitConverter.ToInt32(buf, 0));
        }
        public static IObservable<string> GetMessageBody(this Socket socket,
            int messageSize)
        {
            return socket.GetSocketData(messageSize, buf => 
                Encoding.UTF8.GetString(buf, 0, messageSize));
        }
        public static IObservable<string> GetMessage(this Socket socket)
        {
            return
                from size in socket.GetMessageSize()
                from message in Observable.If(() => size != 0,
                    socket.GetMessageBody(size),
                    Observable.Return<string>(null))
                select message;
        }
        public static IObservable<string> GetMessages(this Socket socket)
        {
            return socket
                .GetMessage()
                .Repeat()
                .TakeWhile(msg => !string.IsNullOrEmpty(msg));
        }
