    protected void Redirect(string url)
        {
            Response.Redirect(url);
        }
    protected void Redirect(string url, NameValueCollection querystrings)
        {
            StringBuilder redirectUrl = new StringBuilder(url);
            if (querystrings != null)
            {
                for (int index = 0; index < querystrings.Count; index++)
                {
                    if (index == 0)
                    {
                        redirectUrl.Append("?");
                    }
                    redirectUrl.Append(querystrings.Keys[index]);
                    redirectUrl.Append("=");
                    redirectUrl.Append(HttpUtility.UrlEncode(querystrings[index]));
                    if (index < querystrings.Count - 1)
                    {
                        redirectUrl.Append("&");
                    }
                }
            }
            this.Redirect(redirectUrl.ToString());
        }
