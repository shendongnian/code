    TReturn UseService<TChannel, TReturn>(Func<TChannel, TReturn> code)
    {
        var chanFactory = GetCachedFactory<TChannel>();
        TChannel channel = chanFactory.CreateChannel();
        bool error = true; 
        try {
            TReturn result = code(channel); 
            ((IClientChannel)channel).Close();
            error = false; 
            return result; 
        }
        finally {
            if (error) {
                ((IClientChannel)channel).Abort();
            }
        }
    }
