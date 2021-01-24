      public void getCategories()
        {
            String host = << Base URI >>;
            String endpoint = << Relative URI >> ";
            String token = "Bearer " +<< admin Token >>;
    
            RestClient restClient = new RestClient(host);
    
            var request = new RestRequest(endpoint, Method.GET);
            request.AddHeader("Authorization", token);
            var rawResponse = restClient.Execute(request);
            var responseBody = rawResponse.Content;
        }
