    [Test]
    public void TestSample()
    {
        string url = "http://www.dreamincode.net/forums/xml.php?showuser=1253";
        string xml;
        using (var webClient = new WebClient())
        {
            xml = webClient.DownloadString(url);
        }
    
        XDocument doc = XDocument.Parse(xml);
    
        // in the result profile with id name is 'Nate'
        string name = doc.XPathSelectElement("/ipb/profile[id='1253']/name").Value;
        Assert.That(name, Is.EqualTo("Nate"));
    }
