    public List<int> GetActivityListforUser(string userId)
    {
        IList<RegionOrganizationActivity> results = new List<RegionOrganizationActivity>();            
        context.LoadStoredProc("dbo.GetRegionOrganizationActivities")
                .WithSqlParam("userId", userId)
                .ExecuteStoredProc((handler) =>
                {    
                    results = handler.ReadToList<RegionOrganizationActivity>();
                });
            return results.Select(activity => activity.Id).ToList();
        }
