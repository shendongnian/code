    interface IMyDynamicEntity {
        string Key { get; set; }
        string Type { get; set; }
    }
    public class MyEntity : IMyDynamicEntity
    {        
        public string Key { get; set; }
        public string Type { get; set; }
        public dynamic Properties { get; } = new MyDynamicProperties();
        private class MyDynamicProperties : DynamicObject {
        }
    }
