    public static class ExtensionMethods
    {
        public static string RelativePath(this HttpServerUtility srv, string path, HttpRequest context)
        {
            return path.Replace(context.ServerVariables["APPL_PHYSICAL_PATH"], "/").Replace(@"\", "/");
        }
    }
