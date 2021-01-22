    public static int NumberUnderReview(int? ownerUserId, List<int> ownerGroupIds)
        {
    
     	var x = ( from c in db.Contacts
                     where 
                     c.Active == true 
                     &&
                     c.LastReviewedOn <= DateTime.Now.AddDays(-365) 
                     &&
                     ( // Owned by group
                        ownerGroupIds.Count == 0 ||
                        ownerGroupIds.Contains( c.OwnerGroupId.Value )
                     )
                     select c );
    
    	if (ownerUserId.HasValue) {
    		x = from a in x
    	    	where c.OwnerUserId.Value == ownerUserId.Value
    	}
    
    	return x.Count();
        }
