            if (scopes.IncludesAllClaimsForUserRule(ScopeType.Identity))
            {
                Logger.Info("All claims rule found - emitting all claims for user.");
                var context = new ProfileDataRequestContext(
                    subject,
                    client,
                    Constants.ProfileDataCallers.ClaimsProviderIdentityToken);
                await _users.GetProfileDataAsync(context);
                
                var claims = FilterProtocolClaims(context.IssuedClaims);
                if (claims != null)
                {
                    outputClaims.AddRange(claims);
                }
                return outputClaims;
            }
