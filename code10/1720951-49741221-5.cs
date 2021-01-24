    [Fact]
    public async Task when_adding_response_headers() {
        // ARRANGE
        var feature = new DummyResponseFeature();
        var context = new DefaultHttpContext();
        context.Features.Set<IHttpResponseFeature>(feature);
        
        RequestDelegate next = async (ctx) => {
            await feature.InvokeCallBack();
        };
        
        var subject = new ResponseHeadersMiddleware(next);
        // ACT
        await subject.Invoke(context);
        // ASSERT
        var response = context.Response;
        Assert.True(response.Headers.TryGetValues("X-Some-Header", out var someHeader));
        Assert.Equals("Foobar", someHeader.FirstOrDefault()
    }
