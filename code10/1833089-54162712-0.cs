        public void requestToken(string email, string passwd)
        {
            var logInfo = new { email = email, passwd = passwd };
            WebClient client = new WebClient();
            Uri uri = new Uri($"{baseURL}/token");
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadStringCompleted += client_requestCompleted; // NOTE THE CHANGE
            client.UploadStringAsync(uri, JsonConvert.SerializeObject(logInfo));
        }
        private void client_requestCompleted(Object sender, UploadStringCompletedEventArgs e)
        {
            // Here is where you will want to chain out to your custom event.
            // In this example I simply pass the original completion event args
            if (requestTokenCompleted != null)
                requestTokenCompleted(this, e);
        }
