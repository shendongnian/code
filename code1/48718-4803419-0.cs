        private const string AspNetNamespace = "ASP";
        
        private static Assembly getApplicationAssembly()
        {
            // Try the EntryAssembly, this doesn't work for ASP.NET classic pipeline (untested on integrated)
            Assembly ass = Assembly.GetEntryAssembly();
            // Look for web application assembly
            HttpContext ctx = HttpContext.Current;
            if (ctx != null)
                ass = getWebApplicationAssembly(ctx);
            // Fallback to executing assembly
            return ass ?? (Assembly.GetExecutingAssembly());
        }
        private static Assembly getWebApplicationAssembly(HttpContext context)
        {
            Guard.AgainstNullArgument(context);
            IHttpHandler handler = context.CurrentHandler;
            if (handler == null) return null;
            Type type = handler.GetType();
            while (type != null && type != typeof(object) && type.Namespace == AspNetNamespace)
                type = type.BaseType;
            return type.Assembly;
        }
