    [Test]
    public void SolrRegistrationOverride()
    {
        // Arrange
        var builder = new ContainerBuilder();
        var serverUrl = ConfigurationManager.ConnectionStrings["solr"].ConnectionString;
        var httpWebRequestFactory = new BasicAuthHttpWebRequestFactory("****", "****");
        var solrNetModule = new SolrNetModule(serverUrl);
        solrNetModule.HttpWebRequestFactory = httpWebRequestFactory;
        builder.RegisterModule(solrNetModule);
        builder.RegisterType<SolrConnection>().AsSelf()
               .WithParameter(new NamedParameter("serverURL", serverUrl))
               .WithProperty("HttpWebRequestFactory", httpWebRequestFactory).AsSelf()
               .SingleInstance();
        builder.RegisterType<PostSolrConnection>().As<ISolrConnection>()
               .WithParameters(new Parameter[]
               {
                   new ResolvedParameter((prm, сtx) => prm.Name == "conn", (prm, ctx) => ctx.Resolve<SolrConnection>()),
                   new NamedParameter("serverUrl", serverUrl)
               });
        var container = builder.Build();
        // Act
        var conn = container.Resolve<ISolrConnection>();
        // Assert
        Assert.IsInstanceOf<PostSolrConnection>(conn);
    }
