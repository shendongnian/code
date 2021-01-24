    public class UnitofWork<T> : IDisposable where T : DbContext, new()
    {
        //Same as you had it, but without TypeAProp and TypeBProp,
        //which we will add to the subclasses below
    }
    public class SqlServerUnitOfWork : UnitOfWork<SqlContext>
    {
        protected DbRepository<TypeB> _typeA;
        public DbRepository<TypeA> TypeAProp
        {
            get
            {
                return _typeA;
            }
        }
    }
    public class OracleUnitOfWork : UnitOfWork<OracleContext>
    {
        protected DbRepository<TypeB> _typeB;
        public DbRepository<TypeB> TypeBProp
        {
            get
            {
                return _typeB;
            }
        }
    }
