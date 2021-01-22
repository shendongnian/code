    **SpringImmediacyControl.cs**
        public abstract class SpringImmediacyControl : ImmediacyControl, ISupportsWebDependencyInjection
        {
            // You can do the same thing for other control classes, like LiteralControl
            #region ISupportsWebDependencyInjection Members
            public IApplicationContext DefaultApplicationContext
            {
                get;
                set;
            }
            
            #endregion
            
            protected override void OnInit(EventArgs e)
            {
                // Required for page preview, which is executed using Immediacy's page preview handler
                
                if (DefaultApplicationContext == null)
                {
                    DefaultApplicationContext = ContextRegistry.GetContext() as WebApplicationContext;
                    DefaultApplicationContext.ConfigureObject(this, this.GetType().FullName);
                }
                base.OnInit(e);
            }
            protected override void AddedControl(Control control, int index)
            {
                this.EnableViewState = false;
                
                // Handle DI for children ourselves - defaults to a call to InjectDependenciesRecursive
                
                if (DefaultApplicationContext != null)
                    WebDependencyInjectionUtils.InjectDependenciesRecursive(DefaultApplicationContext, control);
                base.AddedControl(control, index);
            }
        }
    
     This is similar to [the code for server side controls over on the Spring.NET documentation][2].  However, the extra `OnInit` & null checking code is needed is because the previewer renders the control under Immediacy's own previewer HTTP Handler.  This means a manual call to Spring.NET's context registry is needed to inject dependencies.
