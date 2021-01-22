    public static class EntityHelper<T> where T : ObjectContext
    {
        public static T CreateInstance()
        {
            // get the connection string from config file
            string connectionString = ConfigurationManager.ConnectionStrings[typeof(T).Name].ConnectionString;
            // parse the connection string
            var csBuilder = new EntityConnectionStringBuilder(connectionString);
            // replace * by the full name of the containing assembly
            csBuilder.Metadata = csBuilder.Metadata.Replace(
                "res://*/",
                string.Format("res://{0}/", typeof(T).Assembly.FullName));
            // return the object
            return Activator.CreateInstance(typeof(T), csBuilder.ToString()) as T;
        }
    }
