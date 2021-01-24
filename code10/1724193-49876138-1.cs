        [Test]
        public void ShouldCallClientWithCorrectQueryObjects()
        {
            // Arrange
            Mock<ICustomClient> client = new Mock<ICustomClient>();
            // Permissive on the setup, return good data no matter what the input.
            client.Setup(s => s.GetAccountByAlias(It.IsAny<IEnumerable<CustomQueryModel>>(), It.IsAny<CancellationToken>()))
                  .Returns(new List<ResultModel>());
            CustomQueryModel query = new CustomQueryModel
                                     {
                                         Alias = "alias:12345",
                                         Type = QueryTypes.Alias
                                     };
            CancellationToken cancellationToken = new CancellationToken();
            // Act
            ClassUnderTest test = new ClassUnderTest(client.Object);
            IEnumerable<ResultModel> actualResults = test.MethodConsumingGetAccountByAlias(new[] { query }, cancellationToken);
            // Assert
            Func<IEnumerable<CustomQueryModel>, bool> validateModelFunc = models =>
                                                                          {
                                                                              // Test what you want to about your query parameter
                                                                              List<CustomQueryModel> results = models.ToList();
                                                                              Assert.That(results.Count, Is.EqualTo(1), "Too many elements in queries");
                                                                              Assert.That(results[0], Is.SameAs(query), "Unexpected CustomQueryModel object");
                                                                              return true;
                                                                          };
            // Now we can check that test called client.GetAccountByAlias with the right parameters
            client.Verify(v => v.GetAccountByAlias(It.Is<IEnumerable<CustomQueryModel>>(m => validateModelFunc(m)),
                                                   cancellationToken),
                          Times.Once());
            Assert.That(actualResults, Is.Not.Null); // or whatever
        }
