                var userManager = ctx.GetUserManager<ApplicationUserManager>();
                string sub = result.Identity.FindFirst("sub")?.Value;
                if (userManager.SupportsUserClaim)
                {
                    result.Identity.AddClaims(await userManager.GetClaimsAsync(sub));
                }
                if (userManager.SupportsUserRole)
                {
                    IList<string> roles = await userManager.GetRolesAsync(sub);
                    foreach (string roleName in roles)
                    {
                        result.Identity.AddClaim(new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, roleName, ClaimValueTypes.String));
                    }
                }
