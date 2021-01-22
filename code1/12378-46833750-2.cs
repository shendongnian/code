    private async Task<String> MakeRequestAsync(String url)
    {    
        String responseText = await Task.Run(() =>
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                WebResponse response = request.GetResponse();            
                Stream responseStream = response.GetResponseStream();
                return new StreamReader(responseStream).ReadToEnd();            
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return null;
        });
    
        return responseText;
    }
