    public interface IRepository
    {
       public DataSet ExecuteQuery(string aQuery);
       //Other methods to interact with the DB (such as update or insert) are defined here.
    }
    public class CompanyInfoManager
    {
       private IRepository theRepository;
       public CompanyInfoManager(IRepository aRepository)
       {
          //A repository is required so that we always know what
          //we are talking to.
          theRepository = aRepository;
       }
       public List<string> GetCompanyNames()
       {
          //Query database and return list of company names
          string query = "SELECT * FROM COMPANIES";
          DataSet results = theRepository.ExecuteQuery(query);
          //Process the results...
          return listOfNames;
       }
    }
