    public class RequestModel
    {
        public int Id { get; set; }
        public int RequestTypeId { get; set; }
        public int RequestStatusId { get; set; }
        public string Created { get; set; }
        [ForeignKey("FromUser")]
        public string FromUserId { get; set; }
        [ForeignKey("ToUser")]
        public string ToUserId { get; set; }
        public string RequestData { get; set; }
        public string RequestResult { get; set; }
        public bool RequestIsActive { get; set; }
        
        public ApplicationUser ToUser { get; set; }
        public ApplicationUser FromUser { get; set; }
    
    }
