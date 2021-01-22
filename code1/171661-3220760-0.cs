    var builder = new ContextBuilder<YourContext>();
    
    using (YourContext context = builder.Create(new SqlConnection(ConfigurationManager.ConnectionStrings["yourConenctionKeyInWebConfig"].ConnectionString)))
    {
         ...
    }
