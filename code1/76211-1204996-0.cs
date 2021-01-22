        NameValueCollection fields = new NameValueCollection();
        fields.Add("name1","some text");
        fields.Add("name2","some more text");
        using (var client = new WebClient())
        {
            byte[] resp = client.UploadValues(address, fields);
            // use Encoding to get resp as a string if needed
        }
