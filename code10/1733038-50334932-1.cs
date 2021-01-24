    public static ClaimsIdentity PrimaryIdentitySelector(IEnumerable<ClaimsIdentity> identities)
    {
        //check for null (the default PIS also does this)
        if (identities == null) throw new ArgumentNullException(nameof(identities));
        //if there is only one, there is no need to check further
        if (identities.Count() == 1) return identities.First();
        //Prefer my cookie identity. I can recognize it by the IdentityProvider
        //claim. This doesn't need to be a unique value, simply one that I know
        //belongs to the cookie identity I created. AntiForgery will use this
        //identity in the anti-CSRF check.
        var primaryIdentity = identities.FirstOrDefault(identity => {
            return identity.Claims.FirstOrDefault(c => {
                return c.Type.Equals(StringConstants.ClaimTypes_IdentityProvider, StringComparison.Ordinal) &&
                       c.Value == StringConstants.Claim_IdentityProvider;
            }) != null;
        });
        //if none found, default to the first identity
        if (primaryIdentity == null) return identities.First();
        return primaryIdentity;
    }
