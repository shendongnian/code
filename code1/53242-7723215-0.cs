    @helper GetQueryStringWithValue(string key, string value) {
        var queryString = System.Web.HttpUtility.ParseQueryString(HttpContext.Current.Request.QueryString.ToString());
        queryString[key] = value;
        @Html.Raw(queryString.ToString())
    }
