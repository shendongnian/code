    public class Inventory
    {
        public string Name { get; set; }
        public string RAP { get; set; }
        public string Value { get; set; }
        public List<int> UserAssetIDs { get; set; }
        public List<object> Serials { get; set; }
        public object SerialNumTotal { get; set; }
        public int Copies { get; set; }
        public int AssetID { get; set; }
        public string ImageLink { get; set; }
        public string ItemLink { get; set; }
        public string Img { get; set; }
        public int Demand { get; set; }
        public string ItemID { get; set; }
    }
    public class Stats
    {
        public string RAP { get; set; }
        public string Value { get; set; }
        public string Count { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public bool verified { get; set; }
        public bool is_scammer { get; set; }
        public int percentagechange { get; set; }
        public int ecostatus { get; set; }
        public List<List<object>> rappoints { get; set; }
        public List<List<object>> valuepoints { get; set; }
        public int history_points { get; set; }
        public string Rank { get; set; }
    }
    public class RootObject
    {
        public bool success { get; set; }
        public string reason { get; set; }
        public List<Inventory> inventory { get; set; }
        public Stats stats { get; set; }
    }
