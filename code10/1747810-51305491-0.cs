    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    namespace MYFORM_Form.Controllers
    {
        public class MYController : Controller
        {
    		string organizationUrl = "https://yourcrm.dynamics.com";
    		string appKey = "*****";
    		string aadInstance = "https://login.microsoftonline.com/";
    		string tenantID = "myTenant.onmicrosoft.com";
    		string clientId = "UserGUID****";
    		public Task<String> SendData()
    		{
    			return AuthenticateWithCRM();
    		}
    
    		public async Task<String> AuthenticateWithCRM()
    		{
    			ClientCredential clientcred = new ClientCredential(clientId, appKey);
    			AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID);
    			AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(organizationUrl, clientcred);
    			using (HttpClient httpClient = new HttpClient())
    				{
    					httpClient.BaseAddress = new Uri(organizationUrl);
    					httpClient.Timeout = new TimeSpan(0, 2, 0);  // 2 minutes  
    					httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
    					httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
    					httpClient.DefaultRequestHeaders.Accept.Add(
    					new MediaTypeWithQualityHeaderValue("application/json"));
    					httpClient.DefaultRequestHeaders.Authorization =
    					new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
    					JObject myContact = new JObject
    						{
    							{"[EntityFieldname]", "[ValueToBeAdded]"}
    						};
    
    						HttpResponseMessage CreateResponse = await SendAsJsonAsync(httpClient, HttpMethod.Post, "api/data/v8.2/[EntityName]", myContact);
    						
    						Guid applicationID = new Guid();
    						if (CreateResponse.IsSuccessStatusCode)
    						{
    							string applicationUri = CreateResponse.Headers.GetValues("OData-EntityId").FirstOrDefault();
    							if (applicationUri != null)
    								applicationID = Guid.Parse(applicationUri.Split('(', ')')[1]);
    							Console.WriteLine("Account created Id=", applicationID);
    							return applicationID.ToString();
    						}
    						else
    							return null;
    				}
    					
    		}
    		
    		public static Task<HttpResponseMessage> SendAsJsonAsync<T>(HttpClient client, HttpMethod method, string requestUri, T value)
    		{
    			var content = value.GetType().Name.Equals("JObject") ?
    				value.ToString() :
    				JsonConvert.SerializeObject(value, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore });
    
    			HttpRequestMessage request = new HttpRequestMessage(method, requestUri) { Content = new StringContent(content) };
    			request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
    			request.Headers.Add("User-Agent", "User-Agent-Here");
    			return  client.SendAsync(request);
    		}
    	}
    }
    
    
     
     
    	
