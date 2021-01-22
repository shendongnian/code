        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            this.Session[CacheProvider.ToCacheKey(CacheKeys.LastError)] = ex;
        }
