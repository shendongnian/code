    using(mocks.Record)
    {
       _httpContext = _mocks.DynamicMock<HttpContextBase>();
       SetupResult.For(_httpContext.User).Return(...);
    }
    
    using(mocks.PlayBack())
    {
       ....
    }
