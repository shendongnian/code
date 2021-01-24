    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Authentication;
    
    
    namespace CompanyName.Core2.Application.Middleware
    {
        public class AuthenticationOptions : AuthenticationSchemeOptions
        {
            [UsedImplicitly]
            public AuthenticationIdentities Identities { get; [UsedImplicitly] set; }
    
    
            public AuthenticationOptions()
            {
                Identities = new AuthenticationIdentities();
            }
        }
    }
