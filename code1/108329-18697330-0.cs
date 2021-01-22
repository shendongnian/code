    public partial class WebClient : System.Web.UI.Page
    {        
    #if DEBUG 
        public bool DebugMode = true;
    #else
        public bool DebugMode = false;
    #endif
    }
