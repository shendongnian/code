    // template.cshtml
    @using System.Text.RegularExpressions
    
    @functions {
      public string FixImageUrlParam(string url, int width, int height)
      {
        Regex widthParam = new Regex("w=[0-9]*");
        Regex heightParam = new Regex("h=[0-9]*");
    
        url = widthParam.Replace(url, "w=" + width.ToString());
        url = heightParam.Replace(url, "h=" + height.ToString());
    
        return url;
      }
    }
