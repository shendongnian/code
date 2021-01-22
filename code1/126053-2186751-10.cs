    model.Results = this.Repository.FindGuestByUniqueID( uniqueID, withExpired )
                                   .OrderBy( g => g.Distance )
                                   .Take( 10 )
                                   .ToList()
                                   .Select( g => new GuestGridModel( g ) );
