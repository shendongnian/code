    using(WebClient client = new WebClient()) {
        NameValueCollection values = new NameValueCollection();
        values.Add("id",Id);
        byte[] resp = client.UploadValues("url","POST", values);
    }
