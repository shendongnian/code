    public async Task<HttpResponseMessage> StreamAudioAsync(string id)
    {
        var response = Request.CreateResponse(HttpStatusCode.Moved);
        response.StatusCode = HttpStatusCode.OK;
        using (var wc = new System.Net.WebClient())
        {
            string accessKey = Cp.Service.Settings.AccessKey;
            string secretAccessKey = Cp.Service.Settings.SecretAccessKey;
            string url = string.Format("https://....../......php?access_key={0}&secret_access_key={1}&action=recording.download&format=mp3&sid={2}", accessKey, secretAccessKey, id);
            response.Content = new StreamContent(wc.OpenRead(url));
        }
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
        return response;
    }
