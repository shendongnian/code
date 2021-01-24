    using Flurl.Http;
    [TestMethod]
    public async Task Test_Index()
    {
        // fake & record all HTTP calls in the test subject
        using (var httpTest = new HttpTest())
        {
            // Arrange
            httpTest.RespondWith(200, "<xml>some fake response xml...</xml>");
            DemoController controller = new DemoController();
            // Act
            var result = await controller.Index();
            ViewResult viewResult = (ViewResult) result;
            // Assert
            Assert.AreEqual("Index", viewResult.ViewName);
            Assert.IsNotNull(viewResult.Model);
        }
    }
