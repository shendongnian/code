    public class PluginViewEngine : RazorViewEngine
    {
        private List<string> _plugins = new List<string>();
        public PluginViewEngine()
        {
            var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")).ToList();
               //Load your directory
            plugins.ForEach(s =>
            {
                var di = new DirectoryInfo(s);
                _plugins.Add(di.Name);
            });
            ViewLocationFormats = GetViewLocations();
            MasterLocationFormats = GetMasterLocations();
            PartialViewLocationFormats = GetViewLocations();
        }
        public string[] GetViewLocations()
        {
            var views = new List<string> {
                "~/Views/{1}/{0}.cshtml"
                 };
            _plugins.ForEach(plugin =>
                views.Add("~/Plugins/" + plugin + "/Views/{1}/{0}.cshtml")
            );   //Load your view
            return views.ToArray();
        }
        public string[] GetMasterLocations()
        {
            var masterPages = new List<string> {
                "~/Views/Shared/{0}.cshtml"
                };                
            _plugins.ForEach(plugin =>
                masterPages.Add("~/Plugins/" + plugin + "/Views/Shared/{0}.cshtml")
            );//Load your view
            
            return masterPages.ToArray();
        }
    }
