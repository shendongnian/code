        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Net.Http;
        using System.Net.Http.Headers;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        
        namespace SPORestConsole
        {
            public class SPHttpClient: HttpClient
            {
                public SPHttpClient(Uri webUri, string userName, string password) : base(new SPHttpClientHandler(webUri, userName, password))
                {
                    BaseAddress = webUri;
                }
                /// <summary>
                /// Execure request method
                /// </summary>
                /// <param name="requestUri"></param>
                /// <param name="method"></param>
                /// <param name="headers"></param>
                /// <param name="payload"></param>
                /// <returns></returns>
                public JObject ExecuteJson<T>(string requestUri, HttpMethod method, IDictionary<string, string> headers, T payload)
                {
                    HttpResponseMessage response;
                    switch (method.Method)
                    {
                        case "POST":
                            var requestContent = new StringContent(JsonConvert.SerializeObject(payload));
                            requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                            DefaultRequestHeaders.Add("X-RequestDigest", RequestFormDigest());
                            if (headers != null)
                            {
                                foreach (var header in headers)
                                {
                                    DefaultRequestHeaders.Add(header.Key, header.Value);
                                }
                            }
                            response = PostAsync(requestUri, requestContent).Result;
                            break;
                        case "GET":
                            response = GetAsync(requestUri).Result;
                            break;
                        default:
                            throw new NotSupportedException(string.Format("Method {0} is not supported", method.Method));
                    }
        
                    response.EnsureSuccessStatusCode();
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return String.IsNullOrEmpty(responseContent) ? new JObject() : JObject.Parse(responseContent);
                }
        
                public JObject ExecuteJson<T>(string requestUri, HttpMethod method, T payload)
                {
                    return ExecuteJson(requestUri, method, null, payload);
                }
        
                public JObject ExecuteJson(string requestUri)
                {
                    return ExecuteJson(requestUri, HttpMethod.Get, null, default(string));
                }
        
        
                /// <summary>
                /// Request Form Digest
                /// </summary>
                /// <returns></returns>
                public string RequestFormDigest()
                {
                    var endpointUrl = string.Format("{0}/_api/contextinfo", BaseAddress);
                    var result = this.PostAsync(endpointUrl, new StringContent(string.Empty)).Result;
                    result.EnsureSuccessStatusCode();
                    var content = result.Content.ReadAsStringAsync().Result;
                    var contentJson = JObject.Parse(content);
                    return contentJson["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
                }
            }
        }
   
        using System;
        using System.Net;
        using System.Net.Http;
        using System.Net.Http.Headers;
        using System.Security;
        using System.Threading;
        using System.Threading.Tasks;
        using Microsoft.SharePoint.Client;
        
        namespace SPORestConsole
        {
            public class SPHttpClientHandler : HttpClientHandler
            {
                public SPHttpClientHandler(Uri webUri, string userName, string password)
                {
                    CookieContainer = GetAuthCookies(webUri, userName, password);
                    FormatType = FormatType.JsonVerbose;
                }
        
        
                protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                {
                    request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                    if (FormatType == FormatType.JsonVerbose)
                    {
                        //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json;odata=verbose"));
                        request.Headers.Add("Accept", "application/json;odata=verbose");
                    }
                    return base.SendAsync(request, cancellationToken);
                }
        
        
                /// <summary>
                /// Retrieve SPO Auth Cookies 
                /// </summary>
                /// <param name="webUri"></param>
                /// <param name="userName"></param>
                /// <param name="password"></param>
                /// <returns></returns>
                private static CookieContainer GetAuthCookies(Uri webUri, string userName, string password)
                {
                    var securePassword = new SecureString();
                    foreach (var c in password) { securePassword.AppendChar(c); }
                    var credentials = new SharePointOnlineCredentials(userName, securePassword);
                    var authCookie = credentials.GetAuthenticationCookie(webUri);
                    var cookieContainer = new CookieContainer();
                    cookieContainer.SetCookies(webUri, authCookie);
                    return cookieContainer;
                }
        
        
                public FormatType FormatType { get; set; }
            }
        
            public enum FormatType
            {
                JsonVerbose,
                Xml
            }
        }
