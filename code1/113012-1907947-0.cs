    namespace System.Data.Linq
    {
        public static class DataContextExtensions
        {
            public static bool IsConnected(this DataContext context)
            {
                return (context.Connection.State == ConnectionState.Open);
            }
    
        }
    }
