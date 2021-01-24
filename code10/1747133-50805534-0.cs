    public class SampleContext : IDataBinder<SampleModel>
    {
         private const string getAllSamplesQuery = "SELECT ...";
         private IDbConnection dbConnection;
    
         public SampleContext() => dbConnection = new SqlConnection("...");
    
         public IEnumerable<SampleModel> RetrieveAll() => dbConnection.Query<SampleModel>(getAllSamplesQuery);
    }
