    public void Publish(params object[] arguments)
            {
                ValidationUtils.ArgumentConditionTrue(arguments != null && arguments.Length > 0, "arguments", "At least the name of a file must be specified");
                ValidationUtils.ArgumentNotNullOrEmptyOrWhitespace(arguments[0] as string, "name");
                _name = arguments[0] as string;
    
    
                INetConnectionClient client = _connection.NetConnectionClient;
                RtmpConnection connection = _connection.NetConnectionClient.Connection as RtmpConnection;
                IPendingServiceCallback callback = new CreateStreamCallBack(this, connection, new PublishCallBack(this,_connection, _name));
                client.Call("createStream", callback);
            }
    
            public void AttachFile(string filepath)
            {
                
                FileProvider fileProvider = new FileProvider(this.Scope, new System.IO.FileInfo(filepath));
                _pullPushPipe.Subscribe(fileProvider, null);
                PullAndPush();
            }
    
            public void PullAndPush()
            {
                
                while(true)
                {
                    var msg = _pullPushPipe.PullMessage();
                    if (msg == null)
                    {
                        // No more packets to send
                        Stop();
                        break;
                    }
                    else
                    {
                        if (msg is RtmpMessage)
                        {
                            RtmpMessage rtmpMessage = (RtmpMessage)msg;
                            IRtmpEvent body = rtmpMessage.body;
                         //   SendMessage(rtmpMessage);
                            // Adjust timestamp when playing lists
                            //  EnsurePullAndPushRunning();
                            _pullPushPipe.PushMessage(msg);
                        }
                    }
                }
            }
    
            class PublishCallBack : IPendingServiceCallback
            {
                NetConnection _connection;
                NetStream _stream;
                string _name;
                string _mode;
    
                public PublishCallBack(NetStream stream, NetConnection connection, string name, string mode = "live")
                {
                    _connection = connection;
                    _name = name;
                    _mode = mode;
                    _stream = stream;
                }
    
                public void ResultReceived(IPendingServiceCall call)
                {
                    if ("createStream".Equals(call.ServiceMethodName))
                    {
                        RtmpConnection connection = _connection.NetConnectionClient.Connection as RtmpConnection;
                        object[] args = new object[2] {_name, _mode};
                        PendingCall pendingCall = new PendingCall("publish", args);
                        pendingCall.RegisterCallback(new PublishResultCallBack());
                        connection.Invoke(pendingCall, (byte)connection.GetChannelForStreamId(_stream.StreamId));
                    }
                }
            }
