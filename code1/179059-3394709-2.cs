    public class ExperimentalDataContext: DataContext
    {
        public ExperimentalDataContext(string connectionString) : base(connectionString) { }
        public IExecuteResult ExecuteMethod(object instance, MethodInfo methodInfo, params object[] parameters)
        {
            return this.ExecuteMethodCall(instance, methodInfo, parameters);
        }
        [Function(Name = "dbo.fx_Levenstein", IsComposable = true)]
        public static System.Nullable<double> fx_Levenstein([Parameter(DbType = "NVarChar(255)")] string firstword, [Parameter(DbType = "NVarChar(255)")] string secondword)
        {
            using (ExperimentalDataContext context = new ExperimentalDataContext(GetConnectionString("your-connectionstring")))
            {
                return ((System.Nullable<double>)(context.ExecuteMethod(context, ((MethodInfo)(MethodInfo.GetCurrentMethod())), firstword, secondword).ReturnValue));
            }
        }
        private static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
    }
