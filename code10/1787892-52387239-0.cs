    [Test]
    public async Task ShouldSortOnAllFormulas()
    {
        // Assemble
        const string categoryId = "cameras";
        const string organisationId = "piiick";
        var services = PickContext.GivenServices();
        var pickProvider = services.WhenCreatePickProvider();
        var products = new List<JObject>
        {
            JObject.Parse("{ \"gtin\": \"1\", \"action\": \"No\", \"size\": \"Large\", \"variant\": \"1\" }"),
            JObject.Parse("{ \"gtin\": \"2\", \"action\": \"No\", \"size\": \"Small\", \"variant\": \"1\" }"),
            JObject.Parse("{ \"gtin\": \"3\", \"action\": \"No\", \"size\": \"Small (No Lens)\", \"variant\": \"1\" }")
        };
        var formulas = new List<AnswerFormula>
        {
            new AnswerFormula { Expression = "No", Field = "action", Operator = "=", AnswerId = 170, Filter = true },
            new AnswerFormula { Expression = "Small", Field = "size", Operator = "%", AnswerId = 170, Filter = true },
            new AnswerFormula { Expression = "Small", Field = "size", Operator = "%", AnswerId = 171 }
        };
        services.MockProductProvider.Setup(x => x.ListAvailableMasterProductsAsync(categoryId, organisationId)).ReturnsAsync(products);
        services.MockFilterProvider.Setup(x => x.Filter(products, It.IsAny<List<AnswerFormula>>())).Returns(products);
        // Act
        var uniqueAnswerIds = formulas.Select(m => m.AnswerId).GroupBy(m => m).Select(m => m.First()).ToList();
        await pickProvider.ProcessProductsAsync(formulas, categoryId, organisationId);
        // Assert
        services.MockSortProvider.Verify(x => x.SortAsync(categoryId, products, uniqueAnswerIds));
    }
