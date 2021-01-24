    public class Error
        {
            public class ValidationError
            {
                public string errorCode { get; set; }
                public string path { get; set; }
                public string apiMessage { get; set; }
            }
    
            public class RootObject
            {
                public string resultType { get; set; }
                public string errorType { get; set; }
                public string errorCode { get; set; }
                public string apiMessage { get; set; }
                public List<ValidationError> validationErrors { get; set; }
                public string requestId { get; set; }
            }
        }
