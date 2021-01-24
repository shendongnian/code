    public class DealResponse
    {
        public string detailId { get; set; }
        public string detailcd { get; set; }
        public string fileName { get; set; }
        public string isNgo { get; set; }
    }
    public List<DealResponse> GetDealResponse(string detailId)
    {
        return L2.Union(L1, new DealResponseComprarer())
                 .Where(elm => elm.detailId.Equals(detailId)).ToList();
    }
    L1 = new List<DealResponse>() {
    new DealResponse() { detailId = "5", detailcd = "ABC" , fileName = "string 1", isNgo = "0" },
    new DealResponse() { detailId = "5", detailcd = "DEF" , fileName = "string 2", isNgo = "0" },
    new DealResponse() { detailId = "5", detailcd = "XYZ" , fileName = "string ", isNgo = "0" }};
    L2 = new List<DealResponse>() {
    new DealResponse() { detailId = "5", detailcd = "ABC" , fileName = "string 11", isNgo = "1" },
    new DealResponse() { detailId = "6", detailcd = "MNO" , fileName = "string 3", isNgo = "1" }};
    string ID = "5";
    List<DealResponse> L3 = GetDealResponse(ID);
