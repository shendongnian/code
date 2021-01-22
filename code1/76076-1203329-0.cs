        NameValueCollection fields = new NameValueCollection();
        fields.Add("a","b");
        fields.Add("c","d");
        using (var client = new WebClient())
        {
            byte[] resp = client.UploadValues(address, fields);
            // use Encoding to get resp as a string if needed
        }
