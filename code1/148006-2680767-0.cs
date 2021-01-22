    public class MyBaseController : System.Web.Mvc.Controller
    {
        private AbcDataContext abcDataContext;
        protected AbcDataContext DataContext
        {
            get 
            {   // lazy-create of DataContext
                if (abcDataContext == null)
                    abcDataContext = new AbcDataContext(ConnectionString);
                
                return abcDataContext;
            }
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if( abcDataContext != null )
                    abcDataContext.Dispose();
            }
        }
    }
