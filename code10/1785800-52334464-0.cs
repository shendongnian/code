       public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;
            if (requestTelemetry != null && (HttpContext.Current.Request.HttpMethod == HttpMethod.Post.ToString() || HttpContext.Current.Request.HttpMethod == HttpMethod.Put.ToString()))
            {
                using (var reader = new StreamReader(HttpContext.Current.Request.InputStream))
                {
                    string requestBody = reader.ReadToEnd();
                    int startIndex= requestBody.LastIndexOf("&password=");
                    int endIndex= requestBody.LastIndexOf("&scope=");
                    requestBody = requestBody.Replace(requestBody.Substring(startIndex, (endIndex - startIndex) -1),""); 
                    requestTelemetry.Properties.Add("body", requestBody);
                }
            }
        }
