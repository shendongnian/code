    if (Device.RuntimePlatform == Device.Android)
                {
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/soap+xml"));
                            client.BaseAddress = new Uri(RESTKeys._AndroidPackage);
                            HttpResponseMessage response = await client.GetAsync(RESTKeys._AndroidPackage);
                            using (HttpContent content = response.Content)
                            {
                                string result = await content.ReadAsStringAsync();
                                if (result.Contains("Current Version"))
                                {
                                    int startIndex = result.IndexOf("Current Version</div>") + 66;
                                    result = result.Substring(startIndex);
                                    int endIndex = result.IndexOf("</span>");
                                    result = result.Substring(0, endIndex);
                                    return result.Trim();
                                }
                                else
                                {
                                    return "";
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                }
    
