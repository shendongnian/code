    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {		
    			//Base URL needs to be Specified
    			String host = "http://beta.topprice24.com";
    			//Relative URL needs to be Specified
    			String endpoint = "/rest/default/V1/integration/admin/token";
    
    			RestClient _restClient = new RestClient(host);
    			var request = new RestRequest(endpoint, Method.POST);
    
    			//Initialize Credentials Property
    			var userRequest = new Credentials{username="blabla",password="blabla"};
    			var inputJson = JsonConvert.SerializeObject(userRequest);
    
    			//Request Header
    			request.AddHeader("Content-Type", "application/json");
    			request.AddHeader("Accept", "application/json");
    			//Request Body
    			request.AddParameter("application/json", inputJson, ParameterType.RequestBody);
    						
    			var response = _restClient.Execute(request);
    
    			var token=response.Content;			
            }
        }
    }
