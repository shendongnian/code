    using (WebClient client = new WebClient())
      {
        byte[] response = client.UploadValues(urlToCall, "POST", new NameValueCollection()
        {
            { "test", "value123" }
        });
        result = System.Text.Encoding.UTF8.GetString(response);
      }
