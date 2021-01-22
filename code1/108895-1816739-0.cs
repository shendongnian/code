    [Test]
            public void CanReadFactoryDataService()
            {
                ServiceReference1.DataServiceContext ctx = new
                       ServiceReference1.DataServiceContext(new Uri("http://localhost:1413/DataService.svc"));
                var factories= ctx.Execute<Factory>(
                      new Uri("Factories?Id=54", UriKind.Relative));
                Assert.IsNotNull(factories);
                Factory factory = factories.First<Factory>();
                {
                    Console.WriteLine(factory.ADDRESS);
                }
    
            }
