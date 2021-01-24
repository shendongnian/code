    public class EnterpriseUser
    {
        /// <summary>
        /// Always true for real user
        /// </summary>
        public virtual bool IsAuthentificated => true;
        public static EnterpriseUser Create(string userLinkCode, string partnerLinkCode)
        {
            if (string.IsNullOrEmpty(userLinkCode) ||
                string.IsNullOrEmpty(partnerLinkCode))
            {
                return new DummyEnterpriseUser();
            }
            
            // create true user here with usin link codes
            return new EnterpriseUser(userLinkCode, partnerLinkCode);
        }
        // Some usefull code here
    }
    
    /// <summary>
    /// NullObject implementation for <see cref="EnterpriseUser"/>
    /// </summary>
    public class DummyEnterpriseUser : EnterpriseUser
    {
        /// <summary>
        /// Always false for dummy user
        /// </summary>
        public override bool IsAuthentificated => false;
        public DummyEnterpriseUser()
        {
            
        }
    } 
