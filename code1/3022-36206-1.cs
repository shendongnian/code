    public static T ReadFromRequest < T > (this Controller controller, string key) 
    {
        // Setup
        HttpContextBase context = controller.ControllerContext.HttpContext;
        object val = null;
        T result = default(T);
        // Gaurd
        if (context == null)
            return result; // no point checking request
        // Bind value (check form then query string)
        if (context.Request.Form[key] != null)
            val = context.Request.Form[key];
        if (val == null) 
        {
            if (context.Request.QueryString[key] != null)
                val = context.Request.QueryString[key];
        }
        // Cast value
        if (val != null)
            result = (t)val;
        return result;
    }
    }
