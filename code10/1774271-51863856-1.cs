    class Origin
    {
        public Dictionary<string, PoolData> PoolDatas { get; set; }
    }
    class Destination
    {
        public PoolData[] PoolDatas { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("data.json");
            var data = JsonConvert.DeserializeObject<Origin>(json);
            var destination = new Destination();
            destination.PoolDatas = data.PoolDatas.Select(i =>
            {
                i.Value.FirebaseId = i.Key;
                return i.Value;
            }).ToArray();
        }
    }
