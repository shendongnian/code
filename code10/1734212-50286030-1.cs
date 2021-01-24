    <system.web.webPages.razor>
        ...
        <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Routing" />
            <add namespace="System.Web.Optimization" />
        
            <!-- add the namespace containing static class User here -->
            <add namespace="YourNamespace" />  
        
          </namespaces>
        </pages>
    </system.web.webPages.razor>
