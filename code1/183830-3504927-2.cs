    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "product/getall")]
    Product[] GetAll()
    {
        Product[] prods = new Product[3] {
            new Product() { Name="Foo", Desc="Bar"},
            new Product() {Name="Ha", Desc="Ho"},
            new Product() {Name="Who", Desc="What"}
        };
    
        return prods;
    }
