    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DotNetOpenAuth.OAuth.ChannelElements;
    using DotNetOpenAuth.OAuth.Messages; 
    #endregion
    
    namespace BingMapTest
    {
        public class ConsumerTokenManager : IConsumerTokenManager
        {
            public string ConsumerKey
            {
                get { return "xxxxxxxx"; }
            }
    
            public string ConsumerSecret
            {
                get { return "xxxxxxxx"; }
            }
    
            public string GetTokenSecret(string token)
            {
                return "xxxxxxxx";
            }
    
            public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
            {
                throw new NotImplementedException();
            }
    
            public TokenType GetTokenType(string token)
            {
                throw new NotImplementedException();
            }
    
            public bool IsRequestTokenAuthorized(string requestToken)
            {
                throw new NotImplementedException();
            }
    
            public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
            {
                throw new NotImplementedException();
            }
        }
    }
