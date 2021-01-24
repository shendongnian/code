    public class APICaller
    {
        //make the APICaller singleton in some way here
        //...
        // the api calling method:
        public string CallAPI(string someParameter)
        {
            var response = "";
            using (var client = new HttpClient())
            {
                //calling the API
            }
            return response;
        }
    }
