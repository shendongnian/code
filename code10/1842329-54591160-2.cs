    public static string PostJsonRequest(string endpoint, string userid, string password, string json)
        {
            // Create string to hold JSON response
            string jsonResponse = string.Empty;
            
            using (var client = new WebClient())
            {
                try
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    client.Headers.Set("Authorization", "Basic " + GetEncodedCredentials(userid, password));
                    client.Headers.Add("Content-Type: application/json");
                    client.Headers.Add("Accept", "application/json");
                    var uri = new Uri(endpoint);
                    var response = client.UploadString(uri, "POST", json);
                    jsonResponse = response;
                }
                catch (WebException ex)
                {
                    // Http Error
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        HttpWebResponse wrsp = (HttpWebResponse)ex.Response;
                        var statusCode = (int)wrsp.StatusCode;
                        var msg = wrsp.StatusDescription;
                        throw new HttpException(statusCode, msg);
                    }
                    else
                    {
                        throw new HttpException(500, ex.Message);
                    }
                }
            }
            return jsonResponse;
        }
