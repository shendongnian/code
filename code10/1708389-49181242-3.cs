    public interface IConfigurator
    {
        string GetConnectionString();
    }
    public class SessionConfigurator : IConfigurator
    {
        public string GetConnectionString()
        {
            var connectionString = Session["Con"].ToString();
            return connectionString;
        }
    }
    public static class General
    {
        public IConfigurator Configurator { get; set; }
    
  
        public static string Func1()
        {
            using (SqlConnection con = new SqlConnection(Configurator.GetConnectionString()))
            {
                // My stuff here
            }
        }
    }
