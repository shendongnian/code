using (var session = store.OpenSession())
{
    var merchant = session.Load<Merchant>(idArg);
    
    if (merchant.venues  !=  SOME_CONDITION )
    throw new
        InvalidOperationException("venues have changed. Cannot apply patch Operation");
    	
    List<Venue> venuesList = new List<Venue>();
    if (merchant.venues == null) { 
    	session.Advanced.Patch(merchant, m => m.venues, venuesList); 
    }
    else {
        session.Advanced.Patch(merchant,
        x => x.venues,
        venues => venues.Add(venue));
    }
    session.SaveChanges();
}
  [1]: https://github.com/ravendb/book/blob/v4.0/Ch04/Ch04.md#patching-documents-and-concurrent-modifications
