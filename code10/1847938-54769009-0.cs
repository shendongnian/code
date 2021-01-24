    public class DataProtectionStorage
    {
        private IConnectionMultiplexer _muxer;
        public DataProtectionStorage(string connection)
        {
            _muxer = ConnectionMultiplexer.Connection(connection)
        }
        public string GetDataProtection(string key){
        {
            return _muxer.GetDatabase().StringGet(key);
        }
    }
    public class OtherStorage
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
