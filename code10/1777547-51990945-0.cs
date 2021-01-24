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
