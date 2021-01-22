    public partial class BasePage : System.Web.UI.Page
    {
        protected string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["MyConnectionString"];
            }
        }
    }
