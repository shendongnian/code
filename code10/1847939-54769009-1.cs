    public Interface IOtherStorage
    {
        void StoreItem(string key, string value);
    }
        
    public class OtherStorage : IOtherStorage
    {
        private IConnectionMultiplexer _muxer;
        public OtherStorage(string connection)
        {
            _muxer = ConnectionMultiplexer.Connection(connection)
        }
        public void StoreItem(string key, string value)
        {
            _muxer.GetDatabase().StringSet(key, value);
        }
    }
