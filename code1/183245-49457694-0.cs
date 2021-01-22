    namespace System.Data.Common
    {
        
    
        public static class ProviderExtensions  
        {
    
            private static System.Func<System.Data.Common.DbConnection, System.Data.Common.DbProviderFactory> s_func;
    
    
            static ProviderExtensions()
            {
                System.Linq.Expressions.ParameterExpression p = System.Linq.Expressions.Expression.Parameter(typeof(System.Data.Common.DbConnection));
                System.Linq.Expressions.MemberExpression prop = System.Linq.Expressions.Expression.Property(p, "DbProviderFactory");
                System.Linq.Expressions.UnaryExpression con = System.Linq.Expressions.Expression.Convert(prop, typeof(System.Data.Common.DbProviderFactory));
                System.Linq.Expressions.LambdaExpression exp = System.Linq.Expressions.Expression.Lambda(con, p);
                s_func = (Func<System.Data.Common.DbConnection, System.Data.Common.DbProviderFactory>)exp.Compile();
            } // End Static Constructor  
    
    
            public static System.Data.Common.DbProviderFactory GetProviderByReflection(System.Data.Common.DbConnection conn)
            {
                System.Type t = conn.GetType();
                System.Reflection.PropertyInfo pi = t.GetProperty("DbProviderFactory", 
                      System.Reflection.BindingFlags.NonPublic 
                    | System.Reflection.BindingFlags.Instance
                );
    
                return (System.Data.Common.DbProviderFactory)pi.GetValue(conn);
            } // End Function GetProviderByReflection 
    
    
            public static System.Data.Common.DbProviderFactory GetProvider(this System.Data.Common.DbConnection connection)
            {
                return s_func(connection);
            } // End Function GetProvider 
    
    
            public static System.Data.Common.DbDataAdapter CreateDataAdapter(this System.Data.Common.DbConnection connection)
            {
                System.Data.Common.DbProviderFactory fact = GetProvider(connection);
    
                return fact.CreateDataAdapter();
            } // End Function CreateDataAdapter 
    
    
            public static System.Data.Common.DbDataAdapter CreateDataAdapter(this System.Data.Common.DbConnection connection, System.Data.Common.DbCommand cmd)
            {
                System.Data.Common.DbProviderFactory fact = GetProvider(connection);
    
                System.Data.Common.DbDataAdapter da = fact.CreateDataAdapter();
                da.SelectCommand = cmd;
    
                return da;
            } // End Function CreateDataAdapter 
    
    
        }
    
    
    }
