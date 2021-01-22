    //Class to test CompanyInfoManager
    public class MockRepository : IRepository
    {
       //This method will always return a known value.
       public DataSet ExecuteQuery(string aQuery)
       {
          DataSet returnResults = new DataSet();
          //Fill the data set with known values...
          return returnResults;
       }
    }
    //This will always contain known values that you can test.
    IList<string> names = new CompanyInfoManager(new MockRepository()).GetCompanyNames();
