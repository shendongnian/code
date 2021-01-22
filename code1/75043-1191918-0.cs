        string rawUrl = String.Concat(this.GetApplicationUrl(), Request.RawUrl);
        if (rawUrl.Contains("/post/"))
        {
            bool hasQueryStrings = Request.QueryString.Keys.Count > 1;
            if (hasQueryStrings)
            {
                Uri uri = new Uri(rawUrl);
                rawUrl = uri.GetLeftPart(UriPartial.Path);
                HtmlLink canonical = new HtmlLink();
                canonical.Href = rawUrl;
                canonical.Attributes["rel"] = "canonical";
                Page.Header.Controls.Add(canonical);
            }
        }
