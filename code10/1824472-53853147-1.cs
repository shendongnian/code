    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Aws
    {
        public class CacheInvalidationRequestModel
        {
            public string Region { get; set; }
    
            public string Host { get; set; }
    
            public string AbsolutePath { get; set; }
    
            public string QueryString { get; set; }
    
            public string AccessKey { get; set; }
    
            public string SecretKey { get; set; }
        }
    }
