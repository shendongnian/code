    class MyService : IMyService
    {
        public MyService() : this(new UserAuthorization()) { }
        public MyService(IAuthorization auth) { _auth = auth; }
        private IAuthorization _auth;
        public EntityInfo GetEntityInfo(string entityId)
        {
                _auth.CheckAccessPermission(PermissionType.GetEntity, 
                        user, entityId);
                //Get the entity info
        }
    }
