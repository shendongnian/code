        class ClaimsTransformer : IClaimsTransformation
        {
            public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
            {
                var id = ((ClaimsIdentity)principal.Identity);
                var ci = new ClaimsIdentity(id.Claims, id.AuthenticationType, id.NameClaimType, id.RoleClaimType);
                if (ci.Name.Equals("name"))
                {
                    ci.AddClaim(new Claim("permission", "readOnly"));
                }
                else
                {
                    ci.AddClaim(new Claim("permission", "write"));
               
                }
            
                var cp = new ClaimsPrincipal(ci);
                return Task.FromResult(cp);
            }
        }
