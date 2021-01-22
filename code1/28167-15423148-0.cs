    public class StyleController : Controller
    {
        [OutputCache(Duration = 86400, VaryByParam = "none")]
        public ActionResult Index()
        {
            var cssFiles = Directory.GetFiles(Server.MapPath("~/Views"), "*.css", 
                                              SearchOption.AllDirectories);
            var sb = new StringBuilder();
            foreach (var cssFile in cssFiles)
            {
                sb.Append(System.IO.File.ReadAllText(cssFile));
                sb.Append(Environment.NewLine);
            }
            return Content(sb.ToString(), "text/css");
        }
    }
