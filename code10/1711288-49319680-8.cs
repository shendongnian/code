    public class DefaultIdentityProvider : IIdentityProvider {
        public IIdentity CurrentUser {
            get { return WindowsIdentity.GetCurrent(); }
        }
    }
	
