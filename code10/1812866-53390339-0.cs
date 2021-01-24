        private void ReaderLoop(object state)
        {
            var token = (CancellationToken)state;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var message = MessageQueue.Take(token);
                    OnMessageReceived(new MessageReceivedEventArgs(message));
                }
                catch (OperationCanceledException)
                {
                    if (!disposed && IsRunning)
                        Stop();
                    break;
                }
            }
        }
