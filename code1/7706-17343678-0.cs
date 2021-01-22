    // Web Service Wrapper to override constructor to use custom ConfigSection 
    // app.config values for URL/User/Pass
    namespace myprogram.webservice
    {
        public partial class MyWebService
        {
            public MyWebService(string szURL)
            {
                this.Url = szURL;
                if ((this.IsLocalFileSystemWebService(this.Url) == true))
                {
                    this.UseDefaultCredentials = true;
                    this.useDefaultCredentialsSetExplicitly = false;
                }
                else
                {
                    this.useDefaultCredentialsSetExplicitly = true;
                }
            }
        }
    }
