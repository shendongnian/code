    public interface IRepository
    {
       public ExecuteQuery(string aQuery);
    }
    public class CompanyInfoManager
    {
       private IRepository theRepository;
       public CompanyInfoManager(IRepository aRepository)
       {
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
