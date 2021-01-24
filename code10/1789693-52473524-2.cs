            [Theory]
        [InlineData("/Home")]
        public async Task HttpsRedirectionWithAutoRedirect(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.StartsWith("https://localhost:8080/",
                response.RequestMessage.RequestUri.AbsoluteUri);
        }
