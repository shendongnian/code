    [Fact]
    public async Task Get_QuoteService_ProvidesQuoteInPage()
    {
        // Arrange
        var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IQuoteService, TestQuoteService>();
                });
            })
            .CreateClient();
    
        //Act
        var defaultPage = await client.GetAsync("/");
        var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
        var quoteElement = content.QuerySelector("#quote");
    
        // Assert
        Assert.Equal("Something's interfering with time, Mr. Scarman, " +
            "and time is my business.", quoteElement.Attributes["value"].Value);
    }
