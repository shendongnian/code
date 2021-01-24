    [System.Web.Http.HttpGet]
        public async Task<string> Lookup(string id)
        {
            var temp = HttpContext.Current.Request.QueryString["provider"];
            // do lookup
            return "";
        }
