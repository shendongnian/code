    using JsonFx.Json;
    
    [Serializable]
    [JsonName("MyData")]
    public class MyData
    {
        public int id;
        public string name;
        public int[] stuff;
    }
