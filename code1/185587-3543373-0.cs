    using System;
    
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using Agatha.Common;
    
        public abstract class BaseRequest :Request
            {
            public string UserName { get; set; }
            public string UserDomainName { get; set; }
    
            public string ClientLanguageCode { get; set; }
            public DateTime ClientCreated { get; set; }
            public DateTime ClientSent { get; set; }
            public DateTime ServerReceived { get; set; }
            public DateTime ServerProcessed { get; set; }
    
            public void BeforeSend(IUserContext context)
            {
                ClientSent = DateTime.UtcNow;
                UserName = context.UserName;
                UserDomainName = context.UserDomainName;
                ClientLanguageCode = context.LanguageCode;
            } 
        }
    
    public abstract class BaseResponse : Response
    {
        public DateTime ServerCreated { get; set; }
        public DateTime ServerProcessed { get; set; }
    
        public string[] ValidationErrors { get; set; }
    
        public bool IsValid
        {
            get { return Exception == null & !ValidationErrors.Any(); }
        }
    
    }
