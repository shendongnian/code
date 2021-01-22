    Match mExprStatic = Regex.Match(BaseURL+@"/Site/Categorii/m1", BaseUrl+@"/site/categorii/(?<category>\S*)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
     if (mExprStatic.Success || !string.IsNullOrEmpty(mExprStatic.Value))
     {
        string parameters = "?" + mExprStatic.Groups["category"].Value;
        if ((context.Request.QueryString.AllKeys != null) && (context.Request.QueryString.AllKeys.Length > 0))
        {
           foreach (string key in Request.QueryString.AllKeys)
                  parameters += "&" + key + "=" + Request[key];
        }
      Server.Transfer("~/Site/Categorii.aspx" + parameters , false);
