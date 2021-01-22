    private void HandleIOCompleted(object sender, SocketEventArgs e)
        {
            e.Completed -= this.HandleIOCompleted;
            bool closed = false;
    
            lock (this.sequenceLock) {
                e.SequenceNumber = this.sequenceNumber++;
            }
    
            switch (e.LastOperation) {
                case SocketAsyncOperation.Send:
                case SocketAsyncOperation.SendPackets:
                case SocketAsyncOperation.SendTo:
                    if (e.SocketError == SocketError.Success) {
                        this.OnDataSent(e);
                    }
                    break;
                case SocketAsyncOperation.Receive:
                case SocketAsyncOperation.ReceiveFrom:
                case SocketAsyncOperation.ReceiveMessageFrom:
                    if ((e.BytesTransferred > 0) && (e.SocketError == SocketError.Success)) {
                        this.BeginReceive(e.Socket);
                        if (this.ReceiveTimeout > 0) {
                            this.SetReceiveTimeout(e.Socket);
                        }
                    } else {
                        closed = true;
                    }
    
                    if (e.SocketError == SocketError.Success) {
                        this.OnDataReceived(e);
                    }
                    break;
                case SocketAsyncOperation.Disconnect:
                    closed = true;
                    break;
                case SocketAsyncOperation.Accept:
                case SocketAsyncOperation.Connect:
                case SocketAsyncOperation.None:
                    break;
            }
    
            if (closed) {
                this.HandleSocketClosed(e.Socket);
            }
    
            SocketBufferPool.Instance.Free(e);
        }
