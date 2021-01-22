    // New revised code.
    public static int NumberUnderReview(int? ownerUserId, List<int> ownerGroupIds)
    {
        return ( from c in db.Contacts
                 where 
                 c.Active == true 
                 &&
                 c.LastReviewedOn <= DateTime.Now.AddDays(-365) 
                 &&
                 ( // Owned by user
                    // !ownerUserId.HasValue || 
                    // c.OwnerUserId.Value == ownerUserId.Value
                    ownerUserId.HasValue ? c.OwnerUserId.Value == ownerUserId.Value : true
                 )
                 &&
                 ( // Owned by group
                    // ownerGroupIds.Count == 0 ||
                    // ownerGroupIds.Contains( c.OwnerGroupId.Value )
                    ownerGroupIds.Count != 0 ? ownerGroupIds.Contains( c.OwnerGroupId.Value ) : true
                 )
                 select c ).Count();
    }
