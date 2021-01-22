    var httpResponse = MockRepository.GenerateMock<HttpResponseBase>();
    var cache = MockRepository.GenerateMock<HttpCachePolicyBase>();
       cache.Stub(x => x.SetOmitVaryStar(true));
       httpResponse.Stub(x => x.Cache).Return(cache);
       httpContext.Stub(x => x.Response).Return(httpResponse);
       httpContext.Response.Stub(x => x.Cache).Return(cache);
