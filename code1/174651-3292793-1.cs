    public static void CallSafely<T>(ChannelFactory<T> factory, Action<T> action) where T : class {
        var client = (IClientChannel) factory.CreateChannel();
        bool success = false;
        try {
            action((T) client);
            client.Close();
            success = true;
        } finally {
            if(!success) {
                client.Abort();
            }
        }
    }
