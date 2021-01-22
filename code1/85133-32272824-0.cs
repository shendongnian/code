    _mockResponse = new Mock<HttpResponseBase>();
    _contentType = string.Empty;
    _mockResponse.SetupSet(r => r.ContentType = It.IsAny<string>()).Callback<string>(value => _contentType = value);
    _header = new KeyValuePair<string, string>();
    _mockResponse.Setup(r => r.AddHeader(It.IsAny<string>(), It.IsAny<string>())).Callback((string name, string value) => _header = new KeyValuePair<string, string>(name, value));
    _writer = new StringBuilder();
    _mockResponse.Setup(r => r.Write(It.IsAny<string>())).Callback<string>(s => _writer.Append(s));
    var data = "This is the string to send as response";
    
    UTIL.SendStringAsHttpResponse(data, _mockResponse.Object);
    
    Assert.That(_contentType, Is.EqualTo("application/CSV"));
    Assert.That(_header.Value, Is.EqualTo("attachment; filename=download.csv"));
    Assert.That(_writer.ToString(), Is.EqualTo(data));
