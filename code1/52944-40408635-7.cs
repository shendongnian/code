    using (PrincipalSearchResult<Principal> results = srch.FindAll())
    {
        if (results != null)
        {
            int resultCount = results.Count();
            if (resultCount > 0)  // we have results
            {
                foreach (Principal found in results)
                {
                    string username = found.SamAccountName; // Note, this is not the full user ID!  It does not include the domain.
                }
            }
        }
    }
