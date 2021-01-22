        public static IObservable<int> GetMessageSize(this Socket socket)
        {
            var readSize = Observable
                .FromAsyncPattern<byte[], int, int, SocketFlags, int>(
                socket.BeginReceive,
                socket.EndReceive);
            return Observable.CreateWithDisposable<int>(observer =>
            {
                var buffer = new byte[4];
                return readSize(buffer, 0, 4, SocketFlags.None)
                    .Subscribe(x =>
                        observer.OnNext(BitConverter.ToInt32(buffer, 0)));
            });
        }
        public static IObservable<string> GetMessageBody(this Socket socket, 
            int messageSize)
        {
            var readMessageBody = Observable
                .FromAsyncPattern<byte[], int, int, SocketFlags, int>(
                socket.BeginReceive,
                socket.EndReceive);
            return Observable.CreateWithDisposable<string>(observer =>
            {
                var buffer = new byte[messageSize];
                return readMessageBody(buffer, 0, messageSize, SocketFlags.None)
                    .Subscribe(x => 
                        observer.OnNext(
                        Encoding.UTF8.GetString(buffer, 0, messageSize)));
            });
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
