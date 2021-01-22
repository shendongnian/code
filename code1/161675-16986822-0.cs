        private void Navigate(string helpPath, string version, string context)
        {
            var helpUrl = "http://user:password@site";
            var authHeader = GetAuthHeader();
            _docWindow.Browser.Navigate(helpUrl, string.Empty, null, authHeader);           
            _docWindow.Browser.Navigating += Browser_Navigating;
            
        }
        private string GetAuthHeader()
        {
            byte[] authData = UnicodeEncoding.UTF8.GetBytes(_userName + ":" + _password);
            string authHeader = "Authorization: Basic " + Convert.ToBase64String(authData);
            return authHeader;
        }
        void Browser_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {            
            if (_redirected)
            {
                _redirected = false;
                return;
            }
            var newPage = BaseUrl + e.Uri.AbsolutePath;
            e.Cancel = true;
            _redirected = true;
            _docWindow.Browser.Navigate(newPage, string.Empty, null, GetAuthHeader());
        }
