    // define http://localhost:5000 to be a proxy for http://localhost:53068
    using (var server = new ProxyServer("http://localhost:53068", "http://localhost:5000/"))
    {
        server.Start();
        Console.WriteLine("Press ESC to stop server.");
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
                break;
        }
        server.Stop();
    }
    ....
    public class ProxyServer : IDisposable
    {
        private readonly HttpListener _listener;
        private static readonly HttpClient _client = new HttpClient();
        public ProxyServer(string targetUrl, params string[] prefixes)
            : this(new Uri(targetUrl), prefixes)
        {
        }
        public ProxyServer(Uri targetUrl, params string[] prefixes)
        {
            if (targetUrl == null)
                throw new ArgumentNullException(nameof(targetUrl));
            if (prefixes == null)
                throw new ArgumentNullException(nameof(prefixes));
            if (prefixes.Length == 0)
                throw new ArgumentException(null, nameof(prefixes));
            TargetUrl = targetUrl;
            Prefixes = prefixes;
            _listener = new HttpListener();
            foreach (var prefix in prefixes)
            {
                _listener.Prefixes.Add(prefix);
            }
        }
        public Uri TargetUrl { get; }
        public string[] Prefixes { get; }
        public virtual void Start()
        {
            _listener.Start();
            _listener.BeginGetContext(ProcessRequest, null);
        }
        public virtual void Stop() => _listener.Stop();
        public virtual void Dispose() => ((IDisposable)_listener).Dispose();
        private async void ProcessRequest(IAsyncResult result)
        {
            if (!_listener.IsListening)
                return;
            var ctx = _listener.EndGetContext(result);
            _listener.BeginGetContext(ProcessRequest, null);
            try
            {
                await ProcessRequest(ctx).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                // log error and continue, don't kill our server
            }
        }
        protected virtual async Task ProcessRequestAsync(HttpListenerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            var url = TargetUrl.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped);
            using (var msg = new HttpRequestMessage(new HttpMethod(context.Request.HttpMethod), url + context.Request.RawUrl))
            {
                msg.Version = context.Request.ProtocolVersion;
                if (context.Request.HasEntityBody)
                {
                    var stream = context.Request.InputStream;
                    msg.Content = new StreamContent(stream); // disposed with msg
                }
                foreach (string headerName in context.Request.Headers)
                {
                    var contentHeader = false;
                    var headerValue = context.Request.Headers[headerName];
                    switch (headerName)
                    {
                        // these headers go to content...
                        case "Allow":
                        case "Content-Disposition":
                        case "Content-Encoding":
                        case "Content-Language":
                        case "Content-Length":
                        case "Content-Location":
                        case "Content-MD5":
                        case "Content-Range":
                        case "Content-Type":
                        case "Expires":
                        case "Last-Modified":
                            contentHeader = true;
                            break;
                        // rewrite referer
                        case "Referer":
                            if (Uri.TryCreate(headerValue, UriKind.Absolute, out var referer)) // if relative, don't handle
                            {
                                var builder = new UriBuilder(referer);
                                builder.Host = TargetUrl.Host;
                                builder.Port = TargetUrl.Port;
                                headerValue = builder.ToString();
                            }
                            break;
                        // rewrite host
                        case "Host":
                            headerValue = TargetUrl.Host + ":" + TargetUrl.Port;
                            break;
                    }
                    if (contentHeader)
                    {
                        msg.Content.Headers.Add(headerName, headerValue);
                    }
                    else
                    {
                        msg.Headers.Add(headerName, headerValue);
                    }
                }
                using (var response = await _client.SendAsync(msg).ConfigureAwait(false))
                {
                    using (var os = context.Response.OutputStream)
                    {
                        context.Response.StatusCode = (int)response.StatusCode;
                        context.Response.StatusDescription = response.ReasonPhrase;
                        context.Response.ProtocolVersion = response.Version;
                        foreach (var header in response.Headers)
                        {
                            context.Response.Headers.Add(header.Key, string.Join(", ", header.Value));
                        }
                        foreach (var header in response.Content.Headers)
                        {
                            if (header.Key == "Content-Length") // this will be set automatically at dispose time
                                continue;
                            context.Response.Headers.Add(header.Key, string.Join(", ", header.Value));
                        }
                        using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            await stream.CopyToAsync(context.Response.OutputStream).ConfigureAwait(false);
                        }
                    }
                }
            }
        }
    }
