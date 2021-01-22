    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public void Hello(string name)
        {
          return "Hi " + name;
        }
    }
