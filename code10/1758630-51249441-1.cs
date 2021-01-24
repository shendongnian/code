    public class ObjModel
    {
        public string id { get; set; }
        public string date { get; set; }
        public string name { get; set; }
    }
    ObjModel[] datas = JsonConvert.DeserializeObject<ObjModel[]>(jsonData);
