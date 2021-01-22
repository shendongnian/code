    private void ReloadButton_Click(object sender, RoutedEventArgs e)
    {
        XmlDocument d = new XmlDocument();
        d.LoadXml(@"<Data xmlns=''><Channel>foobar</Channel><Channel>quux</Channel></Data>");
        XmlDataProvider p = Resources["Data"] as XmlDataProvider;
        p.Document = d;
    }
    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        XmlDataProvider p = Resources["Data"] as XmlDataProvider;
        XmlDocument d = p.Document;
        foreach (XmlElement elm in d.SelectNodes("/Data/Channel"))
        {
            elm.InnerText = "Updated";
        }
    }
