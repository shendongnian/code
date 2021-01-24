    [Test]
    public async Task Post_Form() {
        //Arrange
        var stream = getXml();
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
            Name = @"""filename""",
            FileName = @"""req-details.xml""",
        };
        
        var stringContent = new ByteArrayContent(Encoding.UTF8.GetBytes("ZVWSBJXML"));
        stringContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
            Name = @"""VSS_SERV""",
        };
        //could have let system generate it but wanteed to rule it out as a problem
        var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
        var form = new MultipartFormDataContent(boundary);
        //FIX: boundary quote issue
        var contentType = form.Headers.ContentType.Parameters.First(o => o.Name == "boundary");
        contentType.Value = contentType.Value.Replace("\"", String.Empty);
        form.Add(stringContent);
        form.Add(fileContent);
        //var data = await form.ReadAsStringAsync(); //FOR TESTING PORPOSES ONLY!!
        var client = createHttpClient("http://www.rzp.cz/");
        //Act
        var response = await client.PostAsync("cgi-bin/aps_cacheWEB.sh", form);
        var body = await response.Content.ReadAsStringAsync();
        //Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        body.Should().NotBeEmpty();
    }
