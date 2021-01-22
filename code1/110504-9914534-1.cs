    public class Resources
    {
        public static string GetResource(string resourceName)
        {
            string text = resourceName;
            if (System.Web.HttpContext.Current != null)
            {
                var context = new HttpContextWrapper(System.Web.HttpContext.Current);
                var globalResourceObject = context.GetGlobalResourceObject(null, resourceName);
                if (globalResourceObject != null)
                    text = globalResourceObject.ToString();
            }
            return text;
        }
    }
