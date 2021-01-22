public static class ApplicationCaching<K> 
{
        //====================================================================================================================
        public static event EventHandler InitialAccess = (s, e) => { };
        //=============================================================================================
        static Dictionary<string, byte[]> _StoredValues;
        static Dictionary<string, DateTime> _ExpirationTimes = new Dictionary<string, DateTime>();
        //=============================================================================================
        public static int MaxItemCount { get; set; } = 0;
        private static void OnInitialAccess()
        {
            //-----------------------------------------------------------------------------------------
            _StoredValues = new Dictionary<string, byte[]>();
            //-----------------------------------------------------------------------------------------
            InitialAccess?.Invoke(null, EventArgs.Empty);
            //-----------------------------------------------------------------------------------------
        }
        public static void AddToCache<T>(string key, T value, DateTime expirationTime)
        {
            try
            {
                //-----------------------------------------------------------------------------------------
                if (_StoredValues is null) OnInitialAccess();
                //-----------------------------------------------------------------------------------------
                string strValue = JsonConvert.SerializeObject(value);
                byte[] zippedValue = Zipper.Zip(strValue);
                //-----------------------------------------------------------------------------------------
                if (_StoredValues.ContainsKey(key))
                {
                    //-----------------------------------------------------------------------------------------
                    _StoredValues[key] = zippedValue;
                    //-----------------------------------------------------------------------------------------
                    _ExpirationTimes[key] = expirationTime;
                    //-----------------------------------------------------------------------------------------
                }
                else
                {
                    _StoredValues.Add(key, zippedValue);
                    _ExpirationTimes.Add(key, expirationTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============================================================================================
        public static T GetFromCache<T>(string key, T defaultValue = default)
        {
            try
            {
                //-----------------------------------------------------------------------------------------
                if (_StoredValues is null) OnInitialAccess();
                //-----------------------------------------------------------------------------------------
                if (_StoredValues.ContainsKey(key))
                {
                    //------------------------------------------------------------------------------------------
                    if (_ExpirationTimes[key] <= DateTime.Now)
                    {
                        //------------------------------------------------------------------------------------------
                        _StoredValues.Remove(key);
                        _ExpirationTimes.Remove(key);
                        //------------------------------------------------------------------------------------------
                        return defaultValue;
                        //------------------------------------------------------------------------------------------
                    }
                    //------------------------------------------------------------------------------------------
                    byte[] zippedValue = _StoredValues[key];
                    //------------------------------------------------------------------------------------------
                    string strValue = Zipper.Unzip(zippedValue);
                    T value = JsonConvert.DeserializeObject<T>(strValue);
                    //------------------------------------------------------------------------------------------
                    return value;
                    //------------------------------------------------------------------------------------------
                }
                else
                {
                    return defaultValue;
                }
                //---------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //=============================================================================================
        public static string ConvertCacheToString()
        {
            //-----------------------------------------------------------------------------------------
            if (_StoredValues is null || _ExpirationTimes is null) return "";
            //-----------------------------------------------------------------------------------------
            List<string> storage = new List<string>();
            //-----------------------------------------------------------------------------------------
            string strStoredObject = JsonConvert.SerializeObject(_StoredValues);
            string strExpirationTimes = JsonConvert.SerializeObject(_ExpirationTimes);
            //-----------------------------------------------------------------------------------------
            storage.AddRange(new string[] { strStoredObject, strExpirationTimes});
            //-----------------------------------------------------------------------------------------
            string strStorage = JsonConvert.SerializeObject(storage);
            //-----------------------------------------------------------------------------------------
            return strStorage;
            //-----------------------------------------------------------------------------------------
        }
        //=============================================================================================
        public static void InializeCacheFromString(string strCache)
        {
            try
            {
                //-----------------------------------------------------------------------------------------
                List<string> storage = JsonConvert.DeserializeObject<List<string>>(strCache);
                //-----------------------------------------------------------------------------------------
                if (storage != null && storage.Count == 2)
                {
                    //-----------------------------------------------------------------------------------------
                    _StoredValues = JsonConvert.DeserializeObject<Dictionary<string, byte[]>>(storage.First());
                    _ExpirationTimes = JsonConvert.DeserializeObject<Dictionary<string, DateTime>>(storage.Last());
                    //-----------------------------------------------------------------------------------------
                    if (_ExpirationTimes != null && _StoredValues != null)
                    {
                        //-----------------------------------------------------------------------------------------
                        for (int i = 0; i < _ExpirationTimes.Count; i++)
                        {
                            string key = _ExpirationTimes.ElementAt(i).Key;
                            //-----------------------------------------------------------------------------------------
                            if (_ExpirationTimes[key] < DateTime.Now)
                            {
                                ClearItem(key);
                            }
                            //-----------------------------------------------------------------------------------------
                        }
                        //-----------------------------------------------------------------------------------------
                        if (MaxItemCount > 0 && _StoredValues.Count > MaxItemCount)
                        {
                            IEnumerable<KeyValuePair<string, DateTime>> countedOutItems = _ExpirationTimes.OrderByDescending(o => o.Value).Skip(MaxItemCount);
                            for (int i = 0; i < countedOutItems.Count(); i++)
                            {
                                ClearItem(countedOutItems.ElementAt(i).Key);
                            }
                        }
                        //-----------------------------------------------------------------------------------------
                        return;
                        //-----------------------------------------------------------------------------------------
                    }
                    //-----------------------------------------------------------------------------------------
                }
                //-----------------------------------------------------------------------------------------
                _StoredValues = new Dictionary<string, byte[]>();
                _ExpirationTimes = new Dictionary<string, DateTime>();
                //-----------------------------------------------------------------------------------------
            }
            catch (Exception)
            {
                throw;
            }
        }
        //=============================================================================================
        public static void ClearItem(string key)
        {
            //-----------------------------------------------------------------------------------------
            if (_StoredValues.ContainsKey(key))
            {
                _StoredValues.Remove(key);
            }
            //-----------------------------------------------------------------------------------------
            if (_ExpirationTimes.ContainsKey(key))
                _ExpirationTimes.Remove(key);
            //-----------------------------------------------------------------------------------------
        }
        //=============================================================================================
    }
You can easily start using the cache on the fly with something like...
            //------------------------------------------------------------------------------------------------------------------------------
            string key = "MyUniqueKeyForThisItem";
            //------------------------------------------------------------------------------------------------------------------------------
            MyType obj = ApplicationCaching<MyCacheType>.GetFromCache<MyType>(key);
            //------------------------------------------------------------------------------------------------------------------------------
            if (obj == default)
            {
                obj = new MyType(...);
                ApplicationCaching<MyCacheType>.AddToCache(key, obj, DateTime.Now.AddHours(1));
            }
Note the actual types stored in the cache can be the same or different form the cache type. The cache type is ONLY used to differentiate different cache stores.
You can then decide to allow the cache to persist after execution terminates using `Default Settings`
string bulkCache = ApplicationCaching<MyType>.ConvertCacheToString();
                //--------------------------------------------------------------------------------------------------------
                if (bulkCache != "")
                {
                    Properties.Settings.Default.*MyType*DataCachingStore = bulkCache;
                }
                //--------------------------------------------------------------------------------------------------------
                try
                {
                    Properties.Settings.Default.Save();
                }
                catch (IsolatedStorageException)
                {
                    //handle Isolated Storage exceptions here
                }
Handle the InitialAccess Event to reinitialize the cache when you restart the app
private static void ApplicationCaching_InitialAccess(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------------------------------
            string storedCache = Properties.Settings.Default.*MyType*DataCachingStore;
            ApplicationCaching<MyCacheType>.InializeCacheFromString(storedCache);
            //-----------------------------------------------------------------------------------------
        }
Finally here is the Zipper class...
public class Zipper
    {
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];
            int cnt;
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    CopyTo(msi, gs);
                }
                return mso.ToArray();
            }
        }
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopyTo(gs, mso);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
