    public class RequestView
        {
            public int Id { get; set; }
            public int RequestTypeId { get; set; }
            public string RequestTypeName { get; set; }
            public int RequestStatusId { get; set; }
            public string RequestStatusName { get; set; }
            public string Created { get; set; }
    
            public string FromUserId { get; set; }
            public string FromUserName { get; set; }
            
            public string ToUserId { get; set; }
            public string ToUserName { get; set; }
            public string RequestResult { get; set; }
            public bool RequestIsActive { get; set; }
            
        }
