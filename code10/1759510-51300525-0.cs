    public async Task<string> BuildMultipartAsync()
            {
                try
                {
                    MultipartFormDataContent form = new MultipartFormDataContent();
    
                    foreach (PostData p in postData)
                    {
                        form.Add(new StringContent(p.Value), p.Name, p.FileName);
                    }
    
                    foreach (PostDataParam p in postDataParams)
                    {
                        form.Add(new ByteArrayContent(p.data, 0, p.data.Length), p.Name, p.FileName);
                    }
    
                    HttpResponseMessage response = await httpClient.PostAsync(URLCall, form);
    
                    response.EnsureSuccessStatusCode();
                    httpClient.Dispose();
                    string sd = response.Content.ReadAsStringAsync().Result;
                    return sd;
                }catch (Exception e)
                {
                    return e.Message;
                }
            }
