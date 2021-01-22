        /// <summary>
        /// Gets the dynamic web resource URL to reference on the page.
        /// </summary>
        /// <param name="type">The type of the resource.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>Path to the web resource.</returns>
        public string GetScriptResourceUrl(Type type, string resourceName)
        {
            this.scriptResourceUrl = this.currentPage.ClientScript.GetWebResourceUrl(type, resourceName);
            string resourceQueryString = this.scriptResourceUrl.Substring(this.scriptResourceUrl.IndexOf("d="));
            DynamicScriptSessionManager sessMngr = new DynamicScriptSessionManager();
            Guid paramGuid = sessMngr.StoreScriptParameters(this.Parameters);
            return string.Format("/DynamicScriptResource.axd?{0}&paramGuid={1}", resourceQueryString, paramGuid.ToString());
        }
        /// <summary>
        /// Registers the client script include.
        /// </summary>
        /// <param name="key">The key of the client script include to register.</param>
        /// <param name="type">The type of the resource.</param>
        /// <param name="resourceName">Name of the resource.</param>
        public void RegisterClientScriptInclude(string key, Type type, string resourceName)
        {
            this.currentPage.ClientScript.RegisterClientScriptInclude(key, this.GetScriptResourceUrl(type, resourceName));
        }
