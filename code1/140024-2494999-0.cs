    public class Api
    {
        public class MemberApi
        {
          private readonly Api _parent;
          internal MemberApi(Api parent) { _parent = parent; }
          public int GetUserId(string name)
          {
             return _parent._membership.GetIdByName(name);
          }
        }
        #region Constants
        private const int version = 1;
        #endregion
        #region Private Data
        private XProfile _profile;
        private XMembership _membership;
        private XRoles _role;
    
        public MemberApi { get; private set; }
        #endregion Private Data
        public Api()
        {
            _membership =  new XMembership(); 
            _profile = new XProfile();
            _role = new XRoles();
    
            Member = new MemberApi(this);
        }
    }
