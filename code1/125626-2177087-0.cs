    public interface IMyNetworkStream
    {
        int Read([In, Out] byte[] buffer, int offset, int size);
        bool DataAvailable {get;}
    }
