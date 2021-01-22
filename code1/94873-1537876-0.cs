    public interface IShareSpaceGateway {
      IEnumerable<ShareSpace> GetSharedSpaces(string spaceToShare, string emailToShareIt);
    }
    
    public class ShareSpaceGatewayEF: IShareSpaceGateway
    {
      // MySpacesShared should be included up here, not sure what type it is
      public IEnumerable<ShareSpace> GetSharedSpaces(string spaceToShare, string emailToShareIt)
      {
        if (!this.MySpacesShared.IsLoaded) 
         this.MySpacesShared.Load();
    
        return this.MySpacesShared.Any(s => (s.EmailAddress == emailToShareIt) 
                                  & (s.SpaceName == spaceToShare));
      }
    }
