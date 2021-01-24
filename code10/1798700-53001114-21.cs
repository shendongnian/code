    private static HttpClient createHttpClient(string baseAddress) {
        var cookieContainer = new CookieContainer();
        var handler = createHandler(cookieContainer);
        var client = new HttpClient(handler);
        client.BaseAddress = new Uri(baseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "System.Net.Http.HttpClient");
        //client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:62.0) Gecko/20100101 Firefox/62.0");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
        client.DefaultRequestHeaders.TryAddWithoutValidation("DNT", "1");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/xml,text/html,application/xhtml+xml,application/xml");
        client.DefaultRequestHeaders.ExpectContinue = false;
        client.DefaultRequestHeaders.ConnectionClose = false;
        client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() {
            MaxAge = TimeSpan.FromSeconds(0)
        };
        return client;
    }
    private static Stream getXml() {
        var xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <VerejnyWebDotaz 
        xmlns=""urn:cz:isvs:rzp:schemas:VerejnaCast:v1"" 
        version=""2.8"">
        <Kriteria> 
            <IdentifikacniCislo>03358437</IdentifikacniCislo> 
            <PlatnostZaznamu>0</PlatnostZaznamu>
        </Kriteria>
    </VerejnyWebDotaz>";
        var doc = XDocument.Parse(xml);
        var stream = new MemoryStream();
        doc.Save(stream);
        stream.Position = 0;
        return stream;
    }
    private static HttpClientHandler createHandler(CookieContainer cookieContainer) {
        var handler = new HttpClientHandler {
            CookieContainer = cookieContainer,
            UseCookies = true,
            UseDefaultCredentials = true,
        };
        // if the framework supports redirect configuration
        // set max redirect to 3 down from the default 50
        if (handler.SupportsRedirectConfiguration) {
            handler.AllowAutoRedirect = true;
            handler.MaxAutomaticRedirections = 3;
        }
        // if the framework supports automatic decompression set automatic decompression
        if (handler.SupportsAutomaticDecompression) {
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip |
                System.Net.DecompressionMethods.Deflate;
        }
        return handler;
    }
