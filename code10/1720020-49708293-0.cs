    class IrequesttoKness
    {
        public static void LoadHttpPageWithBasicAuthentication(string login, string password, RestClient url)
        {
            var client = url;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password));
            request.AddHeader("Authorization", "Basic" + credentials);
            IRestResponse response = client.Execute(request);
            var html = response.Content;
            Console.WriteLine(html);
        }
    }
