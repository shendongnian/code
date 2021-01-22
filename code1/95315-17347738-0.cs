            string thisPageUrl;
            if (HttpContext.Current.Request.Url.ToString().ToLower().Contains("_layouts"))
            {
                thisPageUrl = SPUtility.ConcatUrls(SPContext.Current.Web.Url, context.Request.Path); //note: cannot rely on Request.Url to be correct !
            }
            else
            {
                thisPageUrl = HttpContext.Current.Request.Url.ToString();
            }
