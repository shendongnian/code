    public enum OutputType
        {
            Png,
            Jpg
        }
    
        public interface IWebThumbAPI
        {
            int Delay { get; set; }
            int Width { get; set; }
            int Height { get; set; }
            OutputType OutputType { get; set; }
            WebThumbAPI Get(string url);
            WebThumbAPI Get(string url, int x, int y, int width, int height);
            System.Drawing.Image SaveSize(WebThumbSize webThumbSize);
        }
    
        public class WebThumbAPI : IWebThumbAPI
        {
            private readonly string apiKey;
            private IList<WebThumbResponse> webThumbResponse;
            private string jobId;
            private string ApiUrl { get; set; }
            public int Delay { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public OutputType OutputType { get; set; }
    
            public WebThumbAPI(string apiKey)
                : this(apiKey, "")
            {
            }
    
            public WebThumbAPI(string apiKey, string jobId)
            {
                this.apiKey = apiKey;
                OutputType = OutputType.Png;
                Width = 1024;
                Height = 768;
                Delay = 5;
                ApiUrl = "http://webthumb.bluga.net/api.php";
                this.jobId = jobId;
            }
    
            public WebThumbAPI Get(string url)
            {
                return Get(url, 0, 0, 400, 200);
            }
    
            public WebThumbAPI Get(string url, int x, int y, int width, int height)
            {
                var outputType = OutputType == OutputType.Jpg ? "jpg" : "png";
    
                var doc = new XDocument(
                    new XElement("webthumb",
                                new XElement("apikey", apiKey),
                                 new XElement("request",
                                                     new XElement("url", url),
                                                     new XElement("outputType", outputType),
                                                     new XElement("width", Width),
                                                     new XElement("height", Height),
                                                     new XElement("delay", Delay),
                                                     new XElement("excerpt",
                                                         new XElement("x", x),
                                                         new XElement("y", y),
                                                         new XElement("width", width),
                                                         new XElement("height", height)))
                        )
                    );
    
                var request = getRequest(doc.ToString());
                var webResponse = (HttpWebResponse)request.GetResponse();
                if (webResponse.ContentType == "text/xml")
                {
                    var stream = webResponse.GetResponseStream();
                    var response = XDocument.Load(XmlReader.Create(stream));
                    webThumbResponse = (from xml in response.Descendants("job")
                                        select new WebThumbResponse
                                        {
                                            Estimate = (int)xml.Attribute("estimate"),
                                            Time = (DateTime)xml.Attribute("time"),
                                            Url = (string)xml.Attribute("url"),
                                            Cost = (int)xml.Attribute("cost"),
                                            Job = (string)xml.Value
                                        }).ToList();
                    stream.Close();
                    if (webThumbResponse.Count == 0)
                        jobId = "-1";
                    else
                    {
                        jobId = webThumbResponse[0].Job;
                        Thread.Sleep(webThumbResponse[0].Estimate * 1000);
                    }
                    
                }
                else
                {
                    throw new InvalidOperationException("Failed request");
                }
                return this;
            }
    
            public System.Drawing.Image SaveSize(WebThumbSize webThumbSize)
            {
                if (jobId == "-1")
                    return defaultImage(webThumbSize);
                var doc = new XDocument(
                    new XElement("webthumb",
                                new XElement("apikey", apiKey),
                                 new XElement("fetch",
                                                     new XElement("job", jobId),
                                                     new XElement("size", Enum.GetName(typeof(WebThumbSize), webThumbSize).ToLower())
                                                     )
                        )
                    );
                var request = getRequest(doc.ToString());
                var webResponse = (HttpWebResponse)request.GetResponse();
                var stream = webResponse.GetResponseStream();
    
                Image image = null;
                try
                {
                    image = System.Drawing.Image.FromStream(stream);
                }
                catch
                {
                    image = defaultImage(webThumbSize);
    
                }
                return image;
            }
    
            private Image defaultImage(WebThumbSize webThumbSize)
            {
                var s = getSize(webThumbSize);
                var b = new Bitmap(s.Width, s.Height);
                var im = Image.FromHbitmap(b.GetHbitmap());
                var gr = System.Drawing.Graphics.FromImage(im);
                gr.Clear(Color.White);
                gr.Dispose();
                return im;
            }
    
            private static System.Drawing.Size getSize(WebThumbSize size)
            {
                switch (size)
                {
                    case WebThumbSize.Small:
                        return new Size(80, 60);
                    case WebThumbSize.Excerpt:
                        return new Size(400, 200);
                    default:
                        return new Size(1, 1);
                }
            }
    
            private HttpWebRequest getRequest(string xml)
            {
                var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
                request.Method = "POST";
                request.Timeout = 20000;
                request.ContentType = "text/xml";
                request.UserAgent = @"Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en) AppleWebKit/418.8 (KHTML, like Gecko) Safari/419.3";
                request.KeepAlive = false;
                request.Pipelined = false;
    
                Stream newStream = request.GetRequestStream();
                var encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(xml);
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                return request;
            }
        }
    
        public class WebThumbResponse
        {
            public DateTime Time;
            public string Job;
            public string Url;
            public int Cost;
            public int Estimate { get; set; }
        }
    
        public enum WebThumbSize
        {
            Small,
            Medium,
            Medium2,
            Large,
            Excerpt
        }
