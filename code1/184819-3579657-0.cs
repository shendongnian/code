     public static Uri SecureIfRemote(this Uri uri){
    
    
    
    if(!System.Web.HttpContext.Current.Request.IsSecureConnection &&
                    !System.Web.HttpContext.Current.Request.IsLocal){
    return new Uri......(build secure uri here)
    }
    
    return uri;
    
        }
    public static NameValueCollection ParseQueryString(Uri uri){
    return uri.Query.ParseQueryString();
    }
        public static NameValueCollection ParseQueryString(this string s)
        {
            //return
            return HttpUtility.ParseQueryString(s);
        }
