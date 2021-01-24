    [Fact]
    public async Task when_adding_response_headers() {
        // ARRANGE
        var feature = new DummyResponseFeature();
        var context = new DefaultHttpContext();
        context.Features.Set<IHttpResponseFeature>(feature);
        
        var subject = new ResponseHeadersMiddleware(next: async (ctx) => {
            
            //invoke callback
            await feature.InvokeCallBack();
            
        });
        // ACT
        await subject.Invoke(context);
        // ASSERT
        var response = context.Response;
        Assert.True(response.Headers.TryGetValues("X-Some-Header", out var someHeader));
        Assert.Equals("Foobar", someHeader.FirstOrDefault()
    }
