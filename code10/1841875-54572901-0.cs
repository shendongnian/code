    <configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
      <sitecore>
        <pipelines>
          <initializeDependencyInjection/>
          <initialize>
            <processor type="Company.Foundation.Example.DependencyInjectionProcessor, Company.Foundation.Example"
                       patch:before="processor[@type='Sitecore.Mvc.Pipelines.Loader.InitializeControllerFactory, Sitecore.Mvc']" />
            <processor type=" Company.Foundation.Example.WebApiDependenceResolverProcessor, Company.Foundation.Example"
                       patch:after="*[@type='Sitecore.PathAnalyzer.Services.Pipelines.Initialize.WebApiInitializer, Sitecore.PathAnalyzer.Services']" />
          </initialize>
        </pipelines>
      </sitecore>
    </configuration>
