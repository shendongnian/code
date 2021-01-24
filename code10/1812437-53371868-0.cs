            public T Execute<T>(RestRequest request, HttpStatusCode expectedResponseCode) where T : new()
        {
            // Won't throw exception.
            var response = _client.Execute<T>(request);
            return response.Data;
        }
        public List<Project> GetProjects()
        {
            var request = new RestRequest()
            {
                Resource = ResourceUrls.Project(),
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };
            return Execute<List<Project>>(request, HttpStatusCode.OK);
        }
