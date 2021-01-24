     public void GetUserFromAD(GraphServiceClient gsc)
        {
            try
            {
                ClaimsIdentity identity = ClaimsPrincipal.Current.Identity as ClaimsIdentity;
                string objectID = identity.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
                var user = gsc.Users[objectID].Request().GetAsync().Result;
                
            }
            catch(Exception ex)
            {
                // do something.
            }
        }
