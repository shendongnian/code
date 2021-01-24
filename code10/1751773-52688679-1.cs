    public override long? UserId
    {
        get
        {
            // ...
            var userIdClaim = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == AbpClaimTypes.UserId);
            // ...
            long userId;
            if (!long.TryParse(userIdClaim.Value, out userId))
            {
                return null;
            }
            return userId;
        }
    }
