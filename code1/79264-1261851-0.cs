    public class PathProvider
    {
        public virtual string GetPath()
        {
            return HttpContext.Current.Server.MapPath("App_Data/ErrorCodes.xml")
        }
    }
    PathProvider pathProvider = new PathProvider();
    XDocument xdoc = XDocument.Load(pathProvider.GetPath());
