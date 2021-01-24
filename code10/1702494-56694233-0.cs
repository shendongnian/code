        private void Initialize()
        {
            this.SPCurrentContext = new ClientContext(this.Url);
            if (string.IsNullOrWhiteSpace(this.Domain))
            {
                this.SPCurrentContext.Credentials = new SharePointOnlineCredentials(this.User, ParseToSecureString(this.Password));
            }
            else
            {
                this.SPCurrentContext.Credentials = new NetworkCredential(this.User, ParseToSecureString(this.Password), this.Domain);
            }
            this.RetryCount = Properties.Settings.Default.DefaultRetryCount;
            this.RetryDelay = Properties.Settings.Default.DefaultRetryDelay;
            this.NONISV = Properties.Settings.Default.ClientAppNONISV;
            this.SPCurrentContext.ExecutingWebRequest += delegate (object sender, WebRequestEventArgs e)
            {
                e.WebRequestExecutor.WebRequest.UserAgent = this.NONISV; // This is the TRICK!!!
            };
        }
