    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class BllServiceCollectionExtensions
        {
    		public static IServiceCollection AddBll(this IServiceCollection services)
    		{ 
    
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<ITransactionService, TransactionService>();
            }
        }
    }
