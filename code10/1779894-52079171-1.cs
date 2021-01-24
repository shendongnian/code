    public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            if (Properties.Settings.Default.Redirect)
            {
                var url = controllerContext.Request.RequestUri;
                url = new Uri(url.AbsoluteUri.Replace(
                  Properties.Settings.Default.OriginalUriFragment,
                  Properties.Settings.Default.ReplacemenUriFragment));
                var client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                foreach (var httpRequestHeader in controllerContext.Request.Headers)
                {
                    client.DefaultRequestHeaders.Add(httpRequestHeader.Key, httpRequestHeader.Value);
                }
                if (controllerContext.Request.Method == HttpMethod.Get)
                {
                    return client.GetAsync(url, cancellationToken);
                }
                if (controllerContext.Request.Method == HttpMethod.Post)
                {
                    return client.PostAsync(url, controllerContext.Request.Content, cancellationToken);
                }
                if (controllerContext.Request.Method == HttpMethod.Delete)
                {
                    return client.DeleteAsync(url, cancellationToken);
                }
                if (controllerContext.Request.Method == HttpMethod.Put)
                {
                    return client.PutAsync(url, controllerContext.Request.Content, cancellationToken);
                }
            }
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
