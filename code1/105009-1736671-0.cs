    public String GetData(String url) {
        WebRequest request = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String data = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return data;
    }
