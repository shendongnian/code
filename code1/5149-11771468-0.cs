    public static class WebViewPageExtensions
    {
        public static string GetFormActionUrl(this WebViewPage view)
        {
            return string.Format("/{0}/{1}/{2}", view.GetController(), view.GetAction(), view.GetId());
        }
        public static string GetController(this WebViewPage view)
        {
            return Get(view, "controller");
        }
        public static string GetAction(this WebViewPage view)
        {
            return Get(view, "action");
        }
        public static string GetId(this WebViewPage view)
        {
            return Get(view, "id");
        }
        private static string Get(WebViewPage view, string key)
        {
            return view.ViewContext.Controller.ValueProvider.GetValue(key).RawValue.ToString();
        }
    }
