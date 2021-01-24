    JsonConvert.DeserializeObject<List<RootObject>>(content);
    public class RootObject
    {
        public string COLUMN_NAME1 { get; set; }
        public string COLUMN_NAME2 { get; set; }
        ....
    }
