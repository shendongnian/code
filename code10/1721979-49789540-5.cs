    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    private const uint COR_E_INVALIDOPERATION = 0x80131509;
    public class StreamObject
    {
        public Stream ContentStream { get; set; }
        public bool ProcessStream { get; set; }
        public Uri ResourceURI { get; set; }
        public Uri ResponseURI { get; set; }
        public string Referer { get; set; }
        public string Payload { get; set; }
        public string ServerType { get; set; }
        public string ServerName { get; set; }
        public IPAddress[] ServerIP { get; set; }
        public string ContentName { get; set; }
        public string ContentType { get; set; }
        public string ContentCharSet { get; set; }
        public string ContentLanguage { get; set; }
        public long ContentLenght { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public WebExceptionStatus WebException { get; set; }
        public string WebExceptionDescription { get; set; }
        public CookieContainer Cookies { get; set; }
    }
    public async Task<StreamObject> HTTP_GetStreamAsync(StreamObject RequestObject)
    {
        if (string.IsNullOrEmpty(RequestObject.ResourceURI.ToString().Trim()))
            return null;
        MemoryStream _memstream = new MemoryStream();
        HttpWebRequest httpRequest;
        CookieContainer _cookiejar = new CookieContainer();
        HttpStatusCode _StatusCode = HttpStatusCode.OK;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |
                                               SecurityProtocolType.Tls |
                                               SecurityProtocolType.Tls11 |
                                               SecurityProtocolType.Tls12;
        ServicePointManager.ServerCertificateValidationCallback += TlsValidationCallback;
        if (RequestObject.Cookies != null && RequestObject.Cookies.Count > 0)
            _cookiejar = RequestObject.Cookies;
        httpRequest = WebRequest.CreateHttp(RequestObject.ResourceURI);
        try
        {
            HTTP_RequestHeadersInit(ref httpRequest, _cookiejar, null);
            httpRequest.Referer = RequestObject.Referer;
            using (HttpWebResponse httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync())
            {
                Stream ResponseStream = httpResponse.GetResponseStream();
                if (_StatusCode == HttpStatusCode.OK)
                {
                    await ResponseStream.CopyToAsync(_memstream);
                    RequestObject.ContentStream = _memstream;
                    RequestObject.ResponseURI = httpResponse.ResponseUri;
                    RequestObject.ContentLenght = _memstream.Length;
                    RequestObject.ContentCharSet = httpResponse.CharacterSet ?? string.Empty;
                    RequestObject.ContentLanguage = httpResponse.Headers["Content-Language"] ?? string.Empty;
                    RequestObject.ContentType = httpResponse.ContentType.ToLower();
                    if (RequestObject.ContentType.IndexOf(@"/") > -1)
                    {
                        do
                        {
                            RequestObject.ContentType = RequestObject.ContentType.Substring(RequestObject.ContentType.IndexOf(@"/") + 1);
                            if (RequestObject.ContentType.IndexOf(@"/") < 0)
                                break;
                        } while (true);
                        if (RequestObject.ContentType.IndexOf(";") > -1)
                            RequestObject.ContentType = RequestObject.ContentType.Substring(0, RequestObject.ContentType.IndexOf(@";"));
                        RequestObject.ContentType = "." + RequestObject.ContentType;
                    }
                    RequestObject.ContentName = httpResponse.Headers["Content-Disposition"] ?? string.Empty;
                    if (RequestObject.ContentName.Length == 0)
                        RequestObject.ContentName = RequestObject.ResourceURI.Segments.Last();
                    RequestObject.ServerType = httpResponse.Server;
                    RequestObject.ServerName = RequestObject.ResponseURI.DnsSafeHost;
                    RequestObject.ServerIP = await Dns.GetHostAddressesAsync(RequestObject.ServerName);
                    RequestObject.StatusCode = _StatusCode;
                    RequestObject.StatusDescription = httpResponse.StatusDescription;
                    if (RequestObject.ProcessStream)
                        RequestObject.Payload = ProcessResponse(RequestObject.ContentStream,
                                                                Encoding.GetEncoding(RequestObject.ContentCharSet),
                                                                httpResponse.ContentEncoding);
                }
            }
        }
        catch (WebException exW)
        {
            if (exW.Response != null)
            {
                RequestObject.StatusCode = ((HttpWebResponse)exW.Response).StatusCode;
                RequestObject.StatusDescription = ((HttpWebResponse)exW.Response).StatusDescription;
            }
            RequestObject.WebException = exW.Status;
            RequestObject.WebExceptionDescription = exW.Message;
        }
        catch (System.Exception exS)
        {
            if ((uint)exS.HResult == COR_E_INVALIDOPERATION)
            {
                RequestObject.WebException = await PingHostAddressAsync("8.8.8.8", 500) > 0
                                           ? WebExceptionStatus.NameResolutionFailure
                                           : WebExceptionStatus.ConnectFailure;
                RequestObject.WebExceptionDescription = RequestObject.WebException.ToString();
            }
            else
            {
                RequestObject.WebException = WebExceptionStatus.RequestCanceled;
                RequestObject.WebExceptionDescription = RequestObject.WebException.ToString();
            }
        }
        finally
        {
            ServicePointManager.ServerCertificateValidationCallback -= TlsValidationCallback;
        }
        RequestObject.Cookies = httpRequest.CookieContainer;
        RequestObject.StatusCode = _StatusCode;
        return RequestObject;
    }   //HTTP_GetStream
    private bool TlsValidationCallback(object sender, X509Certificate CACert, X509Chain CAChain, SslPolicyErrors sslPolicyErrors)
    {
        X509Certificate2 _Certificate = new X509Certificate2(CACert);
        //ADD A CERIFICATE HERE IF NEEDED
        //X509Certificate2 _CACert = new X509Certificate2(@"[localstorage]/ca.cert");
        //CAChain.ChainPolicy.ExtraStore.Add(_CACert);
        X509Certificate2 cert = (X509Certificate2)CACert;
        CAChain.Build(_Certificate);
        foreach (X509ChainStatus CACStatus in CAChain.ChainStatus)
        {
            if ((CACStatus.Status != X509ChainStatusFlags.NoError) &
                (CACStatus.Status != X509ChainStatusFlags.UntrustedRoot))
                return false;
        }
        return true;
    }
    private void HTTP_RequestHeadersInit(ref HttpWebRequest _httpreq, CookieContainer _cookiecontainer, StreamObject sObject)
    {
        _httpreq.Date = DateTime.Now;
        _httpreq.Timeout = 30000;
        _httpreq.ReadWriteTimeout = 30000;
        _httpreq.CookieContainer = _cookiecontainer;
        _httpreq.KeepAlive = true;
        _httpreq.ConnectionGroupName = Guid.NewGuid().ToString();
        _httpreq.AllowAutoRedirect = true;
        _httpreq.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        _httpreq.ServicePoint.MaxIdleTime = 30000;
        _httpreq.ServicePoint.Expect100Continue = false;
        _httpreq.Referer = sObject.Referer ?? string.Empty;
        _httpreq.UserAgent = "Mozilla/5.0 (Windows NT 10; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0";
        _httpreq.Accept = "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        _httpreq.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US;q=0.8,en-GB;q=0.5,en;q=0.3");
        _httpreq.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate;q=0.8");
        _httpreq.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");
        //I had to cut out the WebRequest Proxy setup here
    }
    private string ProcessResponse(Stream stream, Encoding encoding, string ContentEncoding)
    {
        string html = string.Empty;
        stream.Position = 0;
        try
        {
            using (MemoryStream _memStream = new MemoryStream())
            {
                if (ContentEncoding.Contains("gzip"))
                {
                    using (GZipStream _gzipStream = new GZipStream(stream, System.IO.Compression.CompressionMode.Decompress))
                    {
                        _gzipStream.CopyTo(_memStream);
                    };
                }
                else if (ContentEncoding.Contains("deflate"))
                {
                    using (DeflateStream _deflStream = new DeflateStream(stream, System.IO.Compression.CompressionMode.Decompress))
                    {
                        _deflStream.CopyTo(_memStream);
                    };
                }
                else
                {
                    stream.CopyTo(_memStream);
                }
                _memStream.Position = 0;
                using (StreamReader _reader = new StreamReader(_memStream, encoding))
                {
                    html = _reader.ReadToEnd().Trim();
                    html = DecodeMetaCharSetEncoding(_memStream, html, encoding);
                };
            };
        }
        catch (Exception)
        {
            return string.Empty;
        }
        return html;
    }
    private string DecodeMetaCharSetEncoding(Stream memStream, string _html, Encoding _encode)
    {
        Match _match = new Regex("<meta\\s+.*?charset\\s*=\\s*\"?(?<charset>[A-Za-z0-9_-]+)\"?",
                                            RegexOptions.Singleline |
                                            RegexOptions.IgnoreCase).Match(_html);
        if (_match.Success)
        {
            string charset = _match.Groups["charset"].Value.ToLower() ?? "utf-8";
            if ((charset == "unicode") | (charset == "utf-7") | (charset == "utf-16"))
                charset = "utf-8";
            try
            {
                Encoding metaEncoding = Encoding.GetEncoding(charset);
                if (_encode.WebName != metaEncoding.WebName)
                {
                    memStream.Position = 0L;
                    using (StreamReader recodeReader = new StreamReader(memStream, metaEncoding))
                    { _html = recodeReader.ReadToEnd().Trim(); }
                }
            }
            catch (ArgumentException)
            {
                _html = string.Empty;
            }
            catch (Exception)
            {
                _html = string.Empty;
            }
        }
        return _html;
    }
    public async Task<IPStatus> PingHostAddressAsync(string HostAddress, int timeout)
    {
        if (string.IsNullOrEmpty(HostAddress.Trim()))
            return IPStatus.BadDestination;
        byte[] buffer = new byte[32];
        PingReply iReplay = null;
        IPStatus ipStatus;
        using (Ping iPing = new Ping())
        {
            try
            {
                IPAddress _IPAddress = IPAddress.Parse(HostAddress);
                iReplay = await iPing.SendPingAsync(_IPAddress, timeout, buffer, new PingOptions(64, false));
                return iReplay.Status;
            }
            catch (FormatException)
            {
                return IPStatus.BadDestination;
            }
            catch (NotSupportedException nsex)
            {
                ipStatus = (IPStatus)nsex.HResult;
                ipStatus = IPStatus.DestinationProtocolUnreachable;
            }
            catch (PingException pex)
            {
                ipStatus = (IPStatus)pex.HResult;
            }
            catch (SocketException soex)
            {
                ipStatus = (IPStatus)soex.HResult;
            }
            catch (Exception ex)
            {
                //Log ex
                ipStatus = (IPStatus)ex.HResult;
            }
            return (iReplay != null) ? iReplay.Status : ipStatus;
        }
    }
