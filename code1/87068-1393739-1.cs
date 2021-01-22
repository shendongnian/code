     public class Singleton
     {
        public static YourContext _context;
        public static YourContext Context
        {
            get
            {
                //We are in a web app, use a request scope
                if (HttpContext.Current != null)
                {
                    YourContext current_context = (YourContext)HttpContext.Current.Items["_YourContext"];
                    
                    if (current_context == null)
                    {
                        current_context = new YourContext();
                        HttpContext.Current.Items.Add("_YourContext", current_context);                    
                    }
                    return current_context;
                }
                else
                {
                    if (_context == null)
                        _context = new YourContext();
                   
                    return _context;
                }
            }
        }
    }
