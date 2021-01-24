    public interface IRequestHandler
    {
        //Method to get the data of the repo provided by the url
        string GetResult(string keyword, string country);
    }
    // using request handler to get an url address
    public static string GetResult(IRequestHandler requestHandler, string keyword, string country)
    {
        return requestHandler.GetResult(keyword, country);
    }
    public class RestSharpRequestHandler : IRequestHandler
    {
        const string url = "http://universities.hipolabs.com/search";
        public string GetResult(string keyword, string country)
        {
            //"http://universities.hipolabs.com/search?name=" + userInputKeyWord + "&country=" + userInputCountry + "";
            //the values given in the url are GET params, so we add it using RestSharp API
            //also it's unsafe to manually concatenate parameters in url because some values should be encoded according to HTTP specification. Let RestSharp does it for you
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddParameter("name", keyword);
            request.AddParameter("country", country);
            var response = client.Execute(request);
            return response.Content;
        }
    }
