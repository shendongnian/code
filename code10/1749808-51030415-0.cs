    public async Task<IHttpActionResult> GET(string query)
        {
            string _apiUrl = "http://foo.com/rest/services/Geocode?"; 
            string _baseAddress = "http://foo.com/rest/services/Geocode?";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMessage = await client.GetAsync(_apiUrl + query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = responseMessage.Content;
                    return ResponseMessage(response);
                }
            }
            return NotFound();
        }
