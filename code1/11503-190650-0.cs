    WebClient webClient = New WebClient();
    NameValueCollection values = new NameValueCollection();
    values.add("firstname", "Slarti");
    values.add("lastname", "Bart-fast");
    byte[] response = webClient.UploadValues("http://server/path", values);
