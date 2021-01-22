    if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
        foreach (string key in System.Web.HttpContext.Current.Request.Form.Keys) {
            if (key.IndexOf("__VIEWSTATE") == -1) {
                //key:   key
                //value: System.Web.HttpContext.Current.Request.Form[key]
            }
        }
    }
