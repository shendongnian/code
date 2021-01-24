            public async Task<List<Models.AcumaticaCustomerActivities>> GetCustomerActivitiesGIAsync(string filter)
        {
            if (await Login() == false) return null;
            List<Models.AcumaticaCustomerActivities> customerActivities = new List<Models.AcumaticaCustomerActivities>(); ;
            string url = settings.url + settings.endpoint + "AICustomerActivitiesGI?$expand=Result";
            string body = "{ \"ActivityIDGT\" : {value : \"" + filter + "\"} }";  // should be filter's name as exposed via endpoint.
            StringContent reqBody = new StringContent(body, Encoding.UTF8, "application/json");
            var uri = new Uri(url);
            try
            {
                var response = await client.PutAsync(uri, reqBody);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Models.AcumaticaCustomerActivityGIResults results = JsonConvert.DeserializeObject<Models.AcumaticaCustomerActivityGIResults>(content);
                    if (results != null && results.Result != null && results.Result.Count > 0)
                    {
                        customerActivities = results.Result;
                    }
                }
                else
                {
                    err = await response.Content.ReadAsStringAsync();
                    try
                    {
                        ResponseMessage msg = JsonConvert.DeserializeObject<ResponseMessage>(err);
                        if (msg != null && msg.exceptionMessage != "") err = msg.exceptionMessage;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                err = ex.Message;
                return null;
            }
            return customerActivities;
        }
 
