    public static class URLExt {
        public static string GetMimeType(this string url) {
            using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true })) {
                var r = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false).GetAwaiter().GetResult();
                return r.IsSuccessStatusCode ? r.Content.Headers.ContentType.MediaType : null;
            }
        }
    }
