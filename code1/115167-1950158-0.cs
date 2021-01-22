        XmlDocument doc = new XmlDocument();
        using (XmlTextReader tr = new XmlTextReader(new StringReader(xmlString)))
        {
            tr.Namespaces = false;
            doc.Load(tr);
        }
        string woeId = doc.GetElementsByTagName("woeid")[0].InnerText;
