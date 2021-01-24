    public class PluginViewEngine : RazorViewEngine
        {
         
            public PluginViewEngine()
            {
    
                ViewLocationFormats = GetViewLocations();
                MasterLocationFormats = GetMasterLocations();
                PartialViewLocationFormats = GetViewLocations();
    
            }  
            public string[] GetViewLocations()
            {
                var views = new List<string> {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Plugins/Views/{1}/{0}.cshtml" };    
        
                return views.ToArray();
            }
    
            public string[] GetMasterLocations()
            {
                var masterPages = new List<string> {
                    "~/Views/Shared/{0}.cshtml",
                    "~/Plugins/Views/Shared/{0}.cshtml"
                     };
          
                return masterPages.ToArray();
            }
        }
