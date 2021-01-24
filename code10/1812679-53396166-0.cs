    public interface IHttpClientAccessor
    	{
    		HttpClient HttpClient
    		{
    			get;
    		}
    	}
    
    	public class HttpClientAccessor : IHttpClientAccessor
    	{
    		public HttpClientAccessor()
    		{
    			this.HttpClient = new HttpClient();
    		}
    
    		public HttpClient HttpClient
    		{
    			get;
    		}
    	}
    
    	public interface IRestfulService
    	{
    		Task<T> Get<T>(string url, IDictionary<string, string> parameters, IDictionary<string, string> headers = null);
    		Task<T> Post<T>(string url, IDictionary<string, string> parameters, object bodyObject, IDictionary<string, string> headers = null);
    		Task<string> Put(string url, IDictionary<string, string> parameters, object bodyObject, IDictionary<string, string> headers = null);
    		Task<string> Delete(string url, object bodyObject, IDictionary<string, string> headers = null);
    		Task<FileResponse? > Download(string url, IDictionary<string, string> urlParams = null, IDictionary<string, string> headers = null);
    	}
    
    	public class RestfulService : IRestfulService
    	{
    		private HttpClient httpClient = null;
    		private NetworkCredential credentials = null;
    		private IHttpClientAccessor httpClientAccessor;
    		public RestfulService(IConfigurationService configurationService, IHttpClientAccessor httpClientAccessor)
    		{
    			this.ConfigurationService = configurationService;
    			this.httpClientAccessor = httpClientAccessor;
    		}
    
    		public string AuthHeader
    		{
    			get
    			{
    				if (this.Credentials != null)
    				{
    					return string.Format("Basic {0}", Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(this.Credentials.UserName + ":" + this.Credentials.Password)));
    				}
    				else
    				{
    					return string.Empty;
    				}
    			}
    		}
    
    		private IConfigurationService ConfigurationService
    		{
    			get;
    		}
    
    		private string Host => "http://locahost/";
    		private NetworkCredential Credentials => this.credentials ?? new NetworkCredential("someUser", "somePassword");
    		private HttpClient Client => this.httpClient = this.httpClient ?? this.httpClientAccessor.HttpClient;
    		public async Task<T> Get<T>(string url, IDictionary<string, string> parameters, IDictionary<string, string> headers = null)
    		{
    			var result = await this.DoRequest(url, HttpMethod.Get, parameters, null, headers);
    			if (typeof (T) == typeof (string))
    			{
    				return (T)(object)result;
    			}
    			else
    			{
    				return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
    			}
    		}
    
    		private async Task<string> DoRequest(string url, HttpMethod method, IDictionary<string, string> urlParams = null, object bodyObject = null, IDictionary<string, string> headers = null)
    		{
    			string fullRequestUrl = string.Empty;
    			HttpResponseMessage response = null;
    			if (headers == null)
    			{
    				headers = new Dictionary<string, string>();
    			}
    
    			if (this.Credentials != null)
    			{
    				headers.Add("Authorization", this.AuthHeader);
    			}
    
    			headers.Add("Accept", "application/json");
    			fullRequestUrl = string.Format("{0}{1}{2}", this.Host.ToString(), url, urlParams?.ToQueryString());
    			using (var request = new HttpRequestMessage(method, fullRequestUrl))
    			{
    				request.AddHeaders(headers);
    				if (bodyObject != null)
    				{
    					request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(bodyObject), System.Text.Encoding.UTF8, "application/json");
    				}
    
    				response = await this.Client.SendAsync(request).ConfigureAwait(false);
    			}
    
    			var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    			if (!response.IsSuccessStatusCode)
    			{
    				var errDesc = response.ReasonPhrase;
    				if (!string.IsNullOrEmpty(content))
    				{
    					errDesc += " - " + content;
    				}
    
    				throw new HttpRequestException(string.Format("RTC.EmailThreading.Services.RestfulService: Error sending request to web service URL {0}. Reason: {1}", fullRequestUrl, errDesc));
    			}
    
    			return content;
    		}
    	}
