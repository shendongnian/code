		[Fact]
        [Trait("Category", "MyAppController")]
        public void UploadFileTestWorks()
        {
            //Arrange
           var multiPartContent = CreateFakeMultiPartFormData();
            _myApp.Setup(x => x.CheckAndSaveByteStreamAsync(It.IsAny<byte[]>())).ReturnsAsync(() => true);
            var expected = JsonConvert.SerializeObject(
            new WebApiResponse
            {
                Message = "The file has been saved"
            });
			
			_sut = new MyAppController(_myApp.Object);
            //Sets a controller request message content to 
            _sut.Request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = multiPartContent
            };
            //Act
            var retVal = _sut.UploadFile();
            var content = (ResponseMessageResult)retVal.Result;
            var contentResult = content.Response.Content.ReadAsStringAsync().Result;
            //Assert
            contentResult.Should().Be(expected); 
        }
		
