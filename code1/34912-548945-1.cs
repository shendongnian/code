    public Users GetTimeline(Timeline timeline)
    {
        WebClient client = new WebClient();
        XmlDocument document = new XmlDocument();
        string xml = string.Empty;
        byte[] buffer = null;
        client.set_Credentials(this.GetCredentials());
        buffer = client.DownloadData(this.GetTimelineUrl(timeline));
        xml = Encoding.UTF8.GetString(buffer);
        document.LoadXml(xml);
        return this.DecodeStatusXml(document);
    }
 
