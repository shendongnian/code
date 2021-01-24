        public Task ApplyChallenge(OAuthChallengeContext context)
        {
            return Task.FromResult<object>(null);
        }
        public Task RequestToken(OAuthRequestTokenContext context)
        {
            return Task.FromResult<object>(null);
        }
        public Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            string userId = // user id from Token...
            Guid tokenId = // jti from Token...
            string appId = // aud/client id from Token...
            //do the DB check here...
            if (CheckUserToken(userId, tokenId, appId))
            {
                return Task.FromResult<object>(null);
            }
            else
            {
                context.SetError("unauthorized_access", "The supplied security identity for this user is not valid.");
                return Task.FromResult<object>(null);
            }
        }
