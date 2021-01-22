    using (WebClient client = new WebClient())
    {
        NameValueCollection fields = new NameValueCollection();
        fields.Add("foo", "123");
        fields.Add("bar", "abc");
        client.UploadValues(address, fields);
    }
