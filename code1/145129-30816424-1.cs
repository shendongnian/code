    class SampleEntities : DbContext
    {
        public SampleEntities(DbConnection existingConnection, bool contextOwnsConnection) :
                    base(existingConnection, contextOwnsConnection) )
            {
            }
        }
