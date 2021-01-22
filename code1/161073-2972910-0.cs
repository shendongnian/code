    namespace FWS
    {
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
        public class FooService : WebService
        {
            private readonly ILog errorLogger = LogManager.GetLogger("ErrorRollingLogFileAppender");
            private readonly IDaoFactory daoFactory = new DaoFactory();
            private readonly ISession nhSession =  HibernateSessionManager.Instance.GetSession();
        }
        [WebMethod]
        public Bar[] GetFavoriteBars(string someParam, int? onceMore){
            return daoFactory.GetBarDao().GetFavoriteBars(someParam, onceMore); //returns a Bar[]
        }
    }
