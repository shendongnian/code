    public class MyDynamicEntity : DynamicObject, IMyDynamicEntity
    {
        public MyDynamicEntity(string key, string type) {
            Key = key;
            Type = type;
        }
        public string Key { get; }
        public string Type { get; }
    }
