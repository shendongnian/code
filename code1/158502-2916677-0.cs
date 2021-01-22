    public partial class DataContext
    {
    	partial void OnCreated()
    	{
    		this.Connection.ConnectionString =
                         global::System.Configuration.ConfigurationManager
                         .ConnectionStrings["SQLServer"].ConnectionString;
    	}
    }
