    public abstract class BasePage : System.Web.UI.Page
    {
        protected override object LoadPageStateFromPersistenceMedium()
        {
            try
            {
           	    .. return the base, or make here your decompress, or what ever...
                return base.LoadPageStateFromPersistenceMedium();            
            }
            catch (Exception x)
            {
                string vsString = Request.Form[__VIEWSTATE];
                string cThePage = Request.RawUrl;
                
                ...log the x.ToString() error...
                ...log the vsString...
                ...log the ip coming from...
                ...log the cThePage...
    
    	    // check by your self for local errors
                Debug.Fail("Fail to load view state ! Reason:" + x.ToString());
            }
    
            // if reach here, then have fail, so I reload the page - maybe here you
            // can place somthing like ?rnd=RandomNumber&ErrorId=1 and show a message
            Responce.Redirect(Request.RawUrl, true);        
            
            // the return is not used after the redirect
            return string.Empty;
        }    
    }
