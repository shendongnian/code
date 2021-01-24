    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class PagedClientModelList<T> where T : class, new()
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
        [JsonProperty("content")]
        public List<T> Content { get; set; }
        public PagedClientModelList()
        {
            Content = new List<T>();
        }
    }
