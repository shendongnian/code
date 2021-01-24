    public class CreateMenuRequest
    {
        public string MenuName { get; set; }
        
        [JsonIgnore]
        public string UpdatedBy { get; set; }
    }
