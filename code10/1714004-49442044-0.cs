    using (WebClient client = new WebClient())
    {
         byte[] response = client.UploadData(“http://localhost:57772/api/user”, new NameValueCollection()
         {
               {“name”, “Paul”}
         });
    }
