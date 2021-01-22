    public class Connection
    {
        private PortalLandEntities _entities;
        public PortalLandEntities GetEntityConnection()
        {
            return _entities;
        }
        public Connection(PortalLandEntities entities)
        {
            this._entities = entities;
        }
    }
