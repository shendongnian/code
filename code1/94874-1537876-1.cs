    public class Account
    {
      private ISharedSpaceGateway _sharedSpaceGateway;
      public Account(ISharedSpaceGateway sharedSpaceGateway)
      {
        _sharedSpaceGateway = sharedSpaceGateway;
      }
    
      public int ID { get; set; }
      public string Key1 { get; set; }
      public string Key2 { get; set; }
      public string AccountName { get; set; }
    
      public void ShareSpace(string spaceToShare,string emailToShareIt)
      {
        SharedSpace shareSpace = new SharedSpace();
        shareSpace.InvitationCode = Guid.NewGuid().ToString("N");
        shareSpace.DateSharedStarted = DateTime.Now;
        shareSpace.Expiration = DateTime.Now.AddYears(DefaultShareExpirationInYears);
        shareSpace.Active = true;
        shareSpace.SpaceName = spaceToShare;
        shareSpace.EmailAddress = emailToShareIt;
        var sharedSpaces = sharedSpaceGateway.GetSharedSpaces(spaceToShare, emailToShareIt);
        if(sharedSpaces.Count() > 0)    
          throw new InvalidOperationException("Cannot share the a space with a user twice.");
      
        this.MySpacesShared.Add(shareSpace);
      }
    }
