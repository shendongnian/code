    using System.Collections.Specialized;
    
    NameValueCollection filteredQueryString = System.Web.HttpUtility.ParseQueryString(Request.QueryString.ToString());
    filteredQueryString.Remove("appKey");
                
    var queryString = '?'+ filteredQueryString.ToString();
