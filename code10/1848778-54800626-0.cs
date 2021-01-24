     public class Response
            {
                public bool isSuccess { get; set; }
                public string source { get; set; }
                public string number { get; set; }
                public string message { get; set; }
                public bool ShouldSerializemessage()
                {
                    return (!isSuccess); 
                }
                         
                public bool ShouldSerializesource()
                {
                    return (isSuccess);
                }
                public bool ShouldSerializenumber()
                {
                    return (isSuccess);
                }
            }
