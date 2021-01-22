    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ConformanceLevel = ConformanceLevel.Fragment;
    settings.IgnoreWhitespace = true;
    settings.IgnoreComments = true;
    using (HttpWebResponse response = (HttpWebResponse)webreq.GetResponse())
    {
       using (Stream stream = response.GetResponseStream())
       {
           using(XmlReader reader = XmlReader.Create(stream, settings))
           {
               // Do stuff here
           }
       }
    }
