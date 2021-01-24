    private int calls = 0;
    public int Calls {get {return Interlocked.Read(ref calls);}}
    
    protected void MockHttpResponse(string url, string mockedResponse)
    {
            fakeHttpMessageHandler.Setup(f => f.Send(It.Is<HttpRequestMessage>(x => x.RequestUri.AbsoluteUri == url))).Returns(new HttpResponseMessage
            {
                 StatusCode = HttpStatusCode.OK,
                 Content = new StringContent(mockedResponse)
            }).Callback(() => Interlocked.Increment(ref calls));
        }
