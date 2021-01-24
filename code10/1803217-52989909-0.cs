    public class MyUrlDataFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var dict = actionContext.ControllerContext.RequestContext.RouteData.Values;
            List<string> keyList = new List<string>();
            foreach (string key in dict.Keys) keyList.Add(key);
            foreach (string key in keyList)
            {
                string s = dict[key] as string;
                if (s != null) dict[key] = toEnglishNumber(s);
            }
        }
    }
