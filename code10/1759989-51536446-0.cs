    public class MyModel
        {
            public RemoteModel RemoteModel { get; set; }
            public List<KeyMyModel> KeyMyModels { get; set; }
        }
        public class RemoteModel
        {
            public string Id { get; set; } // Identity property this get from remote service
            public string DummyProperty { get; set; } // Some properties returned by remote service
        }
        public class KeyMyModel
        {
            public string Key { get; set; }
            public string MyModelId { get; set; }
        }
        public class Key
        {
            public string KeyStr { get; set; }
            public List<KeyMyModel> KeyMyModels { get; set; }
        }
    
        public interface ICacheService
        {
            List<RemoteModel> Get(string key);
            List<RemoteModel> Get(string key, Func<List<RemoteModel>> getdata);
            Task<List<RemoteModel>> Get(string key, Func<Task<List<RemoteModel>>> getdata);
            void AddOrUpdate(string key, object value);
        }
    
        public class CacheService : ICacheService
        {
            public List<MyModel> MyModels { get; private set; }
            public List<Key> Keys { get; private set; }
            public List<KeyMyModel> KeyMyModels { get; private set; }
    
            public CacheService()
            {
                MyModels = new List<MyModel>();
                Keys = new List<Key>();
                KeyMyModels = new List<KeyMyModel>();
            }
            public List<RemoteModel> Get(string key)
            {
                return MyModels.Where(s => s.KeyMyModels.Any(t => t.Key == key)).Select(s => s.RemoteModel).ToList();
            }
    
            public List<RemoteModel> Get(string key, Func<List<RemoteModel>> getdata)
            {
                var remoteData = getdata();
                Set(key, remoteData);
    
                return MyModels.Where(s => s.KeyMyModels.Any(t => t.Key == key)).Select(t => t.RemoteModel).ToList();
            }
    
            public Task<List<RemoteModel>> Get(string key, Func<Task<List<RemoteModel>>> getdata)
            {
                throw new NotImplementedException();
            }
    
            public void AddOrUpdate(string key, object value)
            {
                throw new NotImplementedException();
            }
    
            public void Invalidate(string key)
            {
    
            }
    
            public void Set(string key, List<RemoteModel> data)
            {
                var Key = Keys.FirstOrDefault(s => s.KeyStr == key) ?? new Key()
                {
                    KeyStr = key
                };
    
                foreach (var remoteModel in data)
                {
                    var exist = MyModels.FirstOrDefault(s => s.RemoteModel.Id == remoteModel.Id);
                    if (exist == null)
                    {
                        // add data to the cache
                        var myModel = new MyModel()
                        {
                            RemoteModel = remoteModel
                        };
                        var keyMyModel = new KeyMyModel()
                        {
                            Key = key,
                            MyModelId = remoteModel.Id
                        };
                        myModel.KeyMyModels.Add(keyMyModel);
                        Key.KeyMyModels.Add(keyMyModel);
                        Keys.Add(Key);
                    }
                    else
                    {
                        exist.RemoteModel = remoteModel;
                        var existKeyMyModel =
                            KeyMyModels.FirstOrDefault(s => s.Key == key && s.MyModelId == exist.RemoteModel.Id);
                        if (existKeyMyModel == null)
                        {
                            existKeyMyModel = new KeyMyModel()
                            {
                                Key = key,
                                MyModelId = exist.RemoteModel.Id
                            };
                            Key.KeyMyModels.Add(existKeyMyModel);
                            exist.KeyMyModels.Add(existKeyMyModel);
                            KeyMyModels.Add(existKeyMyModel);
                        }
                    }
                }
    
                // Remove MyModels if need
                var remoteIds = data.Select(s => s.Id);
                var currentIds = KeyMyModels.Where(s => s.Key == key).Select(s => s.MyModelId);
                var removingIds = currentIds.Except(remoteIds);
                var removingKeyMyModels = KeyMyModels.Where(s => s.Key == key && removingIds.Any(i => i == s.MyModelId)).ToList();
                removingKeyMyModels.ForEach(s =>
                {
                    KeyMyModels.Remove(s);
                    Key.KeyMyModels.Remove(s);
                });
            }
        }
    
        class CacheConsumer
        {
            private readonly CacheService _cacheService = new CacheService();
    
            public List<RemoteModel> GetMyModels(string frontendId, string languageId, string accessId)
            {
                var key = $"{frontendId}_{languageId}_{accessId}";
                return _cacheService.Get(key, () =>
                {
                    // call to remote service here
                    return new List<RemoteModel>();
                });
            }
        }
