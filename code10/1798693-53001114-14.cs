    [Test]
    public async Task _Post() {
        //Arrange
        var stream = getXml();
        var streamContent = new StreamContent(stream);
        streamContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
        streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
            Name = @"""filename""",
            FileName = @"""req-details.xml""",
        };
        var stringContent = new ByteArrayContent(Encoding.UTF8.GetBytes("ZVWSBJXML"));
        stringContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
            Name = @"""VSS_SERV_List""",
        };
        var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
        var form = new MultipartFormDataContent(boundary);
        //FIX: https://stackoverflow.com/questions/30926645/httpcontent-boundary-double-quotes
        var contentType = form.Headers.ContentType.Parameters.First(o => o.Name == "boundary");
        contentType.Value = contentType.Value.Replace("\"", String.Empty);
        form.Add(stringContent);
        form.Add(streamContent);
        var client = createHttpClient("http://www.rzp.cz/");
        //Act
        var response = await client.PostAsync("cgi-bin/aps_cacheWEB.sh", form);
        var body = await response.Content.ReadAsStringAsync();
        //Assert        
        response.IsSuccessStatusCode.Should().BeTrue();
        body.Should().NotBeEmpty();
    }
