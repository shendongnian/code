    public partial class TnsDb : DbContext, IDatabase {
        public TnsDbDev()
            : base("name=TnsDb")
        {
        }
    
        public virtual ObjectResult<Method_1_Result> Method_1(Nullable<int> id, string username)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Method_1_Result>("Method_1", idParameter, usernameParameter);
        }
    
        public virtual ObjectResult<Method_2_Result> Method_2(string username, string password)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Method_2_Result>("Method_2", usernameParameter, passwordParameter);
        }
    }
    
    public partial class SngDb : DbContext, IDatabase {
        public SngDbDev()
            : base("name=SngDb")
        {
        }
    
        public virtual ObjectResult<Method_1_Result> Method_1(Nullable<int> id, string username)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Method_1_Result>("Method_1", idParameter, usernameParameter);
        }
    
        public virtual ObjectResult<Method_2_Result> Method_2(string username, string password)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Method_2_Result>("Method_2", usernameParameter, passwordParameter);
        }
    }
    
