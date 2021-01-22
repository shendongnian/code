	// Dependency-Inject this
	public ISharedSpacesPersistenceService SharedSpacesPersistenceService { get; set; }
	
	public void ShareSpace(string spaceToShare,string emailToShareIt)
	{
		SharedSpace shareSpace = new SharedSpace();
		shareSpace.InvitationCode = Guid.NewGuid().ToString("N");
		shareSpace.DateSharedStarted = DateTime.Now;
		shareSpace.Expiration = DateTime.Now.AddYears(DefaultShareExpirationInYears);
		shareSpace.Active = true;
		shareSpace.SpaceName = spaceToShare;
		shareSpace.EmailAddress = emailToShareIt;
		
		if(SharedSpacesPersistenceService.ContainsSpace(s.EmailAddress, spaceToShare)
			throw new InvalidOperationException("Cannot share the a space with a user twice.");		
		
		this.MySpacesShared.Add(shareSpace);
	}
