    public partial class DataContext
    {
        partial void OnCreated()
        {
            this.Connection.ConnectionString =       
            ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        } 
    }
