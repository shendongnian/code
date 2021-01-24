[c#]
            var mockRequest = new HttpRequest("", "http://tempuri.org", "");
            HttpContext.Current = new HttpContext(
                mockRequest,
                new HttpResponse(new StringWriter())
            );
            mockRequest.GetType().InvokeMember(
                "_logonUserIdentity", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance, 
                System.Type.DefaultBinder,
                mockRequest,
                new object[] { WindowsIdentity.GetCurrent() }
            );
