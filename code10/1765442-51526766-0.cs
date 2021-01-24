    public List<int> GetActivityListforUser(string userId)
        {
            ActivityId temp = new ActivityId();
    
            List<ActivityId> results = new List<ActivityId>();
            context.LoadStoredProc("dbo.GetRegionOrganizationActivities")
                    .WithSqlParam("userId", userId)
                    .ExecuteStoredProc((handler) =>
                    {
                        results = handler.ReadToList<ActivityId>().ToList();
                    });
            List<int> finalresult = new List<int>();
    
             finalresult = results.Select(a=>a.Id).ToList();
    
            return finalresult.ToList();
         
        }
    
        public  class ActivityId
        {
            public int Id { get; set; }
        }
