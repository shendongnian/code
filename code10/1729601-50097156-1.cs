            //Creating a Fake HTTP Context           
            // This is used for testing methods using Session Variables.
            private HttpContext FakeHttpContext()
            {
                var httpRequest = new HttpRequest("", "http://somethig.com/", "");
                var stringWriter = new StringWriter();
                var httpResponce = new HttpResponse(stringWriter);
                var httpContext = new HttpContext(httpRequest, httpResponce);
    
                var sessionContainer = 
                    new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                        new HttpStaticObjectsCollection()
                                                        , 10,
                                                        true,
                                                        HttpCookieMode.AutoDetect,
                                                        SessionStateMode.InProc, false);
    
                httpContext.Items["AspSession"] = 
                    typeof(HttpSessionState).GetConstructor(
                                            BindingFlags.NonPublic | BindingFlags.Instance,
                                            null, CallingConventions.Standard,
                                            new[] { typeof(HttpSessionStateContainer) },
                                            null)
                                    .Invoke(new object[] { sessionContainer });
    
                return httpContext;
            }
