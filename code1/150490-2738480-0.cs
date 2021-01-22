    public ObjectState State
        {
            get
            {
                ServerManager server = null;
                ObjectState result = ObjectState.Unknown;
                try
                {
                    server = ServerManager.OpenRemote(address);
                    result = server.ApplicationPools[name].State;
                }
                finally
                {
                    if (server != null)
                        server.Dispose();
                }
                return result;
            }
        }
