            WebGui webGui = new WebGui();
            host = new WebServiceHost(webGui, new Uri("http://localhost:" + Port));
            var bindings = new WebHttpBinding();
            host.AddServiceEndpoint(typeof(IWebGui), bindings, "");
            host.Open();
