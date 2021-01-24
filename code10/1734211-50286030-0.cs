    <system.web.webPages.razor>
        ...
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Routing" />
            <add namespace="System.Web.Optimization" />
        
            <!-- add here -->
            <add namespace="YourNamespace.User" />  
        
          </namespaces>
        </pages>
    </system.web.webPages.razor>
