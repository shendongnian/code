            [Theory]
        [InlineData("/Home")]
        public async Task HttpsRedirectionWithoutAutoRedirect(string url)
        {
            // Arrange
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions
                                    {
                                        AllowAutoRedirect = false
                                    });
            // Act
            var response = await client.GetAsync(url);
            // Assert
            Assert.Equal(HttpStatusCode.RedirectKeepVerb, response.StatusCode);
            Assert.StartsWith("http://localhost/",
                response.RequestMessage.RequestUri.AbsoluteUri);
            Assert.StartsWith("https://localhost:8080/",
                response.Headers.Location.OriginalString);
        }
