        using System.Net.Http;
        HttpClient client = new HttpClient();
        public async Task<List<Object>> GetObjectAsync()
        {
            try
            {
                string url = "http://yourapiurl.com/";
                var response = await client.GetStringAsync(url);
                var objectsReturned = JsonConvert.DeserializeObject<List<Object>>(response);
                return objectsReturned;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public async Task AddObjectAsync(Object object)
        {
            try
            {
                string url = "http://yourapiurl.com/{0}";
                var uri = new Uri(string.Format(url, object.Id));
                var data = JsonConvert.SerializeObject(object);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
