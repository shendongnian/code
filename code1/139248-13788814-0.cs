    class extendedWebBrowser : WebBrowser
    {
        /// <summary>
        /// Default constructor which will make the browser to ignore all errors
        /// </summary>
        public extendedWebBrowser()
        {
            this.ScriptErrorsSuppressed = true;
                
            FieldInfo field = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                 object axIWebBrowser2 = field.GetValue(this);
                 axIWebBrowser2.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, axIWebBrowser2, new object[] { true });
            }
        }
    }
