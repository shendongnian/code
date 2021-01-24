    private string password = "yourpassword";
    private string localhost = "127.0.0.1";                              
    private async Task DeleteProfile()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (interfaceGUID != null)
                    {
                        string deleteCommand = "netsh wlan delete profile name=*";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, string.Format("http://{0}:8080/api/iot/processmanagement/runcommand?command={1}&runasdefaultaccount={2}", localhost, Convert.ToBase64String(Encoding.UTF8.GetBytes(deleteCommand)), Convert.ToBase64String(Encoding.UTF8.GetBytes("no")))))
                        {
                            request.Headers.Authorization = CreateBasicCredentials("Administrator");
                            using (HttpResponseMessage response = await client.SendAsync(request))
                            {
                                if (response.IsSuccessStatusCode == true)
                                {
                                     ShutdownManager.BeginShutdown(Windows.System.ShutdownKind.Shutdown, TimeSpan.FromSeconds(1));
                                }
                                else
                                {
                                    Debug.WriteLine("Could not delete the profiles. " + response.ReasonPhrase.ToString());
                                }
                            }
                        }
                    }
                    client.Dispose();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not delete the profiles. " + ex.InnerException.ToString());
            }
        }
    private AuthenticationHeaderValue CreateBasicCredentials(string userName)
        {
            string toEncode = userName + ":" + password;
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            byte[] toBase64 = encoding.GetBytes(toEncode);
            string parameter = Convert.ToBase64String(toBase64);
            return new AuthenticationHeaderValue("Basic", parameter);
        }
