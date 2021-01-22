    /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.1433")]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]       
     [System.Web.Services.WebServiceBindingAttribute(Name="MyBinding", Namespace="http://example.com")]
        public partial class MyWebClient : WebServicesClientProtocol {
    
            // ... member variables here
    
            /// <remarks/>
            public MyWebClient()
            {
                this.Url = "http://example.com";           
                if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                    this.UseDefaultCredentials = true;
                    this.useDefaultCredentialsSetExplicitly = false;
                }
                else {
                    this.useDefaultCredentialsSetExplicitly = true;
                }
    
                // Apply policy here
                Policy policy = new Policy();
                policy.Assertions.Add(new MyAssertion());
                this.SetPolicy(policy); 
            }
      }
