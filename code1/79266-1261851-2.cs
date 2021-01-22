    public class PathProvider
    {
        public virtual string GetPath()
        {
            return HttpContext.Current.Server.MapPath("App_Data/ErrorCodes.xml");
        }
    }
