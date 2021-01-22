public ActionResult Open(){            
   string[] keys = Request.QueryString.AllKeys;
   Dictionary<string, object> queryParams = new Dictionary<string, object>();
   foreach (string key in keys)
   {
     queryParams[key] = Request.QueryString[key];
   }
   string sort = queryParams["sort"];
   ...
   
