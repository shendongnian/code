    public class ResponseData
    {
        public object ContentID { get; set; }
        public string ProductVersionEvritChildren { get; set; }
        public string BookVisualsVersion { get; set; }
        public string iconDescriptionPage { get; set; }
        public bool IsBetaOnly { get; set; }
        public int ProductType { get; set; }
        public int ProductID { get; set; }
    }
    
    public class RootObject
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ResponseData> ResponseData { get; set; }
    }
    var data = JsonConvert.DeserializeObject<RootObject>(jsonString);
    
    data.ResponseData.Where(r => FreeBooksProductId.Contains(r.ProductID)).ToList();
