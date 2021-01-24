    String url = "/myFolder?bar=1#baz";
    Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
    if (!uri.IsAbsoluteUri)
    {
        Uri baseUri = new Uri("http://foo.com");
        uri = new Uri(baseUri, uri);
    }
                    
    String pathAndQuery = uri.PathAndQuery; // /myFolder?bar=1
    String query = uri.Query; // ?bar=1
    String fragment = uri.Fragment; // #baz
