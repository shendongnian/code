    using System;
    using System.IO;
    using System.Web;
    
    namespace RequestFilterModuleTest
    {
        public class RequestFilterModule : IHttpModule
        {
            #region Implementation of IHttpModule
    
            /// <summary>
            /// Initializes a module and prepares it to handle requests.
            /// </summary>
            /// <param name="context">
            /// An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, 
            /// properties, and events common to all application objects within an ASP.NET application 
            /// </param>
            public void Init(HttpApplication context)
            {
                context.BeginRequest += ContextBeginRequest;
            }
    
            /// <summary>
            /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
            /// </summary>
            public void Dispose()
            {
            }
    
            private static void ContextBeginRequest(object sender, EventArgs e)
            {
                var context = (HttpApplication) sender;
    
                // this is the file in question
                string requestPhysicalPath = context.Request.PhysicalPath;
    
                if (File.Exists(requestPhysicalPath))
                {
                    return;
                }
    
                // file does not exist. do something interesting here.....
            }
    
            #endregion
        }
    }
--------------------------------------------
    <?xml version="1.0"?>
    <configuration>
    	...............................
    	<system.web>
    	...........................
    		<httpModules>
    			<add name="RequestFilterModule" type="RequestFilterModuleTest.RequestFilterModule"/>
    			<add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
    		</httpModules>
    	</system.web>
    	...................
    </configuration>
