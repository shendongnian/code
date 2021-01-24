    if (_inquiryview.ValidTest == "1")
            {
                HttpContext context = HttpContext.Current;
                HttpCachePolicy cachePolicy = HttpContext.Current.Response.Cache;
                cachePolicy.SetCacheability(HttpCacheability.ServerAndPrivate);
                cachePolicy.SetExpires(DateTime.Now.AddDays(15));
                cachePolicy.VaryByHeaders["Accept"] = true;
                cachePolicy.VaryByHeaders["Accept-Charset"] = true;
                cachePolicy.VaryByHeaders["Accept-Encoding"] = true;
                cachePolicy.VaryByParams["*"] = true;
                cachePolicy.SetValidUntilExpires(true);
            }
