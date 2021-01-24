    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    
    namespace redirect
    {
        public class reverseProxy
        {
            //public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //{
            //    return true;
            //}
    
            public static void ProcessRequest(HttpContext Context, string newHost)
            {
    
                //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    
                /* Create variables to hold the request and response. */
                HttpRequest Request = Context.Request;
                HttpResponse Response = Context.Response;
    
                string URI = null;
                URI = Request.Url.Scheme.ToString() + "://" + newHost + Request.Url.PathAndQuery;
                
                /* Create an HttpWebRequest to send the URI on and process results. */
                System.Net.HttpWebRequest ProxyRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URI);
    
    
                /* Set the same requests to our request as in the incoming request */
                ProxyRequest.Method = Request.HttpMethod.ToUpper();
                ProxyRequest.ServicePoint.Expect100Continue = false;
                ProxyRequest.Accept = Request.Headers["Accept"];
                //ProxyRequest.TransferEncoding = Request.Headers["Accept-encoding"];
                ProxyRequest.SendChunked = false;
                //ProxyRequest.Date = Request.Headers["Date"];
                ProxyRequest.Expect = Request.Headers["Expect"];
                //ProxyRequest.IfModifiedSince = Request.Headers["If-Modified-Since"];
                //ProxyRequest.Range = Request.Headers["Range"];
                ProxyRequest.Referer = Request.Headers["Referer"];
                ProxyRequest.TransferEncoding = Request.Headers["Transfer-Encoding"];
                ProxyRequest.UserAgent = Request.Headers["User-Agent"];
                
                //set the same headers except for certain ones as they need to be set not in this way
                foreach (string strKey in Request.Headers.AllKeys)
                {
                    if ((strKey != "Accept") && (strKey != "Connection") && (strKey != "Content-Length") && (strKey != "Content-Type") && (strKey != "Date") && (strKey != "Expect") && (strKey != "Host") && (strKey != "If-Modified-Since") && (strKey != "Range") && (strKey != "Referer") && (strKey != "Transfer-Encoding") && (strKey != "User-Agent") && (strKey != "Proxy-Connection") && (strKey != "hostingauth"))
                    ProxyRequest.Headers.Add(strKey, Request.Headers[strKey]);
                }
                
                if (Request.InputStream.Length > 0)
                {
                    /* 
                     * Since we are using the same request method as the original request, and that is 
                     * a POST, the values to send on in the new request must be grabbed from the 
                     * original POSTed request.
                     */
                    byte[] Bytes = new byte[Request.InputStream.Length];
                    Request.InputStream.Read(Bytes, 0, (int)Request.InputStream.Length);
                    ProxyRequest.ContentLength = Bytes.Length;
                    string ContentType = Request.ContentType;
    
                    if (String.IsNullOrEmpty(ContentType))
                    {
                        ProxyRequest.ContentType = "application/x-www-form-urlencoded";
                    }
                    else
                    {
                        ProxyRequest.ContentType = ContentType;
                    }
    
                    using (Stream OutputStream = ProxyRequest.GetRequestStream())
                    {
                        OutputStream.Write(Bytes, 0, Bytes.Length);
                    }
                }
                //else
                //{
                //    /*
                //     * When the original request is a GET, things are much easier, as we need only to 
                //     * pass the URI we collected earlier which will still have any parameters 
                //     * associated with the request attached to it.
                //     */
                //    //ProxyRequest.Method = "GET";
                //}
                
                System.Net.WebResponse ServerResponse = null;
    
                /* Send the proxy request to the remote server or fail. */
                try
                {
                    //even if it isn't gzipped it tries but ignores if it fails
                    ProxyRequest.AutomaticDecompression = DecompressionMethods.GZip;
                    ServerResponse = ProxyRequest.GetResponse();
                }
                catch (System.Net.WebException WebEx)
                {
                    #region exceptionError
                    Response.StatusCode = 500;
                    Response.StatusDescription = WebEx.Status.ToString();
                    Response.Write(WebEx.Message);
                    Response.Write("\r\n");
                    Response.Write(((System.Net.HttpWebResponse)WebEx.Response).ResponseUri);
                    Response.Write("\r\n");
                    Response.Write(((System.Net.HttpWebResponse)WebEx.Response).Method);
                    Response.Write("\r\n");
                    Response.Write("Headers\r\n");
                    foreach (string strKey in Request.Headers.AllKeys)
                    {
                        Response.Write(strKey + ": " +Request.Headers[strKey]);
                        Response.Write("\r\n");
                    }
                    Response.End();
                    #endregion
                    return;
                }
                
                /* Set up the response to the client if there is one to set up. */
                if (ServerResponse != null)
                {
                    Response.ContentType = ServerResponse.ContentType;
                    using (Stream ByteStream = ServerResponse.GetResponseStream())
                    {
                        /* What is the response type? */
                        if (ServerResponse.ContentType.Contains("text") ||
                                ServerResponse.ContentType.Contains("json") ||
                                ServerResponse.ContentType.Contains("xml"))
                        {
                            /* These "text" types are easy to handle. */
                            using (StreamReader Reader = new StreamReader(ByteStream))
                            {
                                string ResponseString = Reader.ReadToEnd();
    
                                /* 
                                 * Tell the client not to cache the response since it 
                                 * could easily be dynamic, and we do not want to mess
                                 * that up!
                                 */
                                Response.CacheControl = "no-cache";
                             
                                //If the request came with a gzip request, send it back gzipped
                                if (Request.Headers["Accept-encoding"].Contains("gzip"))
                                {
                                    Response.Filter = new System.IO.Compression.GZipStream(Response.Filter,
                                          System.IO.Compression.CompressionMode.Compress);
                                    Response.AppendHeader("Content-Encoding", "gzip");
                                }
    
                                //write webpage/results back
                                Response.Write(ResponseString);
                                
                            }
                        }
                        else
                        {
    
                            //This is completely untested
    
                            /* 
                             * Handle binary responses (image, layer file, other binary 
                             * files) differently than text.
                             */
                            BinaryReader BinReader = new BinaryReader(ByteStream);
    
                            byte[] BinaryOutputs = BinReader.ReadBytes((int)ServerResponse.ContentLength);
    
                            BinReader.Close();
    
                            /* 
                             * Tell the client not to cache the response since it could 
                             * easily be dynamic, and we do not want to mess that up!
                             */
                            Response.CacheControl = "no-cache";
    
                            //could this make it more efficient - untested
                            if (Request.Headers["Accept-encoding"].Contains("gzip"))
                            {
                                Response.Filter = new System.IO.Compression.GZipStream(Response.Filter,
                                      System.IO.Compression.CompressionMode.Compress);
                                Response.AppendHeader("Content-Encoding", "gzip");
                            }
    
    
                            /*
                             * Send the binary response to the client.
                             * (Note: if large images/files are sent, we could modify this to 
                             * send back in chunks instead...something to think about for 
                             * future.)
                             */
                            Response.OutputStream.Write(BinaryOutputs, 0, BinaryOutputs.Length);
                        }
                        ServerResponse.Close();
                    }
                }
                
                //done
                Response.End();
            }
    
    
        }
    }
