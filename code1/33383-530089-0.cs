            var hebe = new HttpValueCollection();
            hebe.Add(HttpUtility.ParseQueryString(Request.Url.Query));
            if (!string.IsNullOrEmpty(hebe["Language"]))
                hebe.Remove("Language");
            Response.Redirect(Request.Url.AbsolutePath + "?" + hebe );
