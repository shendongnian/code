        var url = System.Web.HttpContext.Current.Server.MapPath(@"~/Content/data.json");
        string s = string.Empty;
        using (System.IO.StreamReader sr = new System.IO.StreamReader(url, System.Text.Encoding.UTF8,true))
        {
              s = sr.ReadToEnd();
        }
 
