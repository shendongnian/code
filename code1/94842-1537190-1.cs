            using (WebClient client = new WebClient())
            {
                NameValueCollection fields = new NameValueCollection();
                fields.Add("query", query);
                byte[] respBytes = client.UploadValues(url, fields);
                string resp = client.Encoding.GetString(respBytes);
            }
