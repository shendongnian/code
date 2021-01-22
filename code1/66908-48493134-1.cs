    /// <summary>
    /// Flags an Action Method valid for any incoming request only if all, any or none of the given HTTP parameter(s) are set,
    /// enabling the use of multiple Action Methods with the same name (and different signatures) within the same MVC Controller.
    /// </summary>
    public class RequireParameterAttribute : ActionMethodSelectorAttribute
    {
        public RequireParameterAttribute(string parameterName) : this(new[] { parameterName })
        {
        }
    
        public RequireParameterAttribute(params string[] parameterNames)
        {
            IncludeGET = true;
            IncludePOST = true;
            IncludeCookies = false;
            Mode = MatchMode.All;
        }
    
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            switch (Mode)
            {
                case MatchMode.All:
                default:
                    return (
                        (IncludeGET && ParameterNames.All(p => controllerContext.HttpContext.Request.QueryString.AllKeys.Contains(p)))
                        || (IncludePOST && ParameterNames.All(p => controllerContext.HttpContext.Request.Form.AllKeys.Contains(p)))
                        || (IncludeCookies && ParameterNames.All(p => controllerContext.HttpContext.Request.Cookies.AllKeys.Contains(p)))
                        );
                case MatchMode.Any:
                    return (
                        (IncludeGET && ParameterNames.Any(p => controllerContext.HttpContext.Request.QueryString.AllKeys.Contains(p)))
                        || (IncludePOST && ParameterNames.Any(p => controllerContext.HttpContext.Request.Form.AllKeys.Contains(p)))
                        || (IncludeCookies && ParameterNames.Any(p => controllerContext.HttpContext.Request.Cookies.AllKeys.Contains(p)))
                        );
                case MatchMode.None:
                    return (
                        (!IncludeGET || !ParameterNames.Any(p => controllerContext.HttpContext.Request.QueryString.AllKeys.Contains(p)))
                        && (!IncludePOST || !ParameterNames.Any(p => controllerContext.HttpContext.Request.Form.AllKeys.Contains(p)))
                        && (!IncludeCookies || !ParameterNames.Any(p => controllerContext.HttpContext.Request.Cookies.AllKeys.Contains(p)))
                        );
            }
        }
    
        public string[] ParameterNames { get; private set; }
    
        /// <summary>
        /// Set it to TRUE to include GET (QueryStirng) parameters, FALSE to exclude them:
        /// default is TRUE.
        /// </summary>
        public bool IncludeGET { get; set; }
    
        /// <summary>
        /// Set it to TRUE to include POST (Form) parameters, FALSE to exclude them:
        /// default is TRUE.
        /// </summary>
        public bool IncludePOST { get; set; }
    
        /// <summary>
        /// Set it to TRUE to include parameters from Cookies, FALSE to exclude them:
        /// default is FALSE.
        /// </summary>
        public bool IncludeCookies { get; set; }
    
        /// <summary>
        /// Use MatchMode.All to invalidate the method unless all the given parameters are set (default).
        /// Use MatchMode.Any to invalidate the method unless any of the given parameters is set.
        /// Use MatchMode.None to invalidate the method unless none of the given parameters is set.
        /// </summary>
        public MatchMode Mode { get; set; }
    
        public enum MatchMode : int
        {
            All,
            Any,
            None
        }
    }
